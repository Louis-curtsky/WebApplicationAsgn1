using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAsgn1.Models.Person;

namespace WebApplicationAsgn1.Controllers
{
    public class PersonController : Controller
    {
        IPeopleService _peopleService;
        IPeopleRepo _memoryPeople;

        public PersonController()
        {
            _memoryPeople = new IMemoryPeopleRepo();
            _peopleService = new PeopleService();
            
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            if (! _memoryPeople.Initialize())
            {
                return View(_memoryPeople.GetPersons());
            }
            else
                return View(_memoryPeople.All());
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Searching()
        {
            CreatePersonViewModel searchPeople = new CreatePersonViewModel();
            searchPeople.CityList = _memoryPeople.Getcities();

            return View(searchPeople);
        }

        public IActionResult GetPersonList()
        {
            return PartialView("_PersonList", _memoryPeople.GetPersons());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPerson = new CreatePersonViewModel();
            createPerson.CityList = _memoryPeople.Getcities();
            return View(createPerson);
        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            return View(_peopleService.SearchResult());
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPeople)
        {
            if (ModelState.IsValid)
            {
         //                _memoryPeople.Initialize();
                _peopleService.Add(createPeople.FirstName, createPeople.LastName, createPeople.City, createPeople.Phone);
                return RedirectToAction("Index");
            }

            createPeople.CityList = _memoryPeople.Getcities();

            return View(createPeople);
        }


        [HttpPost]
        public IActionResult Searching(CreatePersonViewModel searchPeople)
        {
          List<Person> peopleSearch = new List<Person>();
          string seacrhString = searchPeople.FirstName + "|" + searchPeople.LastName + "|" + searchPeople.City;
          peopleSearch =  _peopleService.Search(seacrhString);
          if (peopleSearch != null)
              return RedirectToAction("SearchResult");
          else
              return View();
        }

    }
}
