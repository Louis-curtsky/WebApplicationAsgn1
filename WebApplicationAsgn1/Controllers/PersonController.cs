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
        IMemoryPeopleRepo _memoryPeople;

        public PersonController()
        {
            _peopleService = new PeopleService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View(_peopleService.All());
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
            searchPeople.CityList = _peopleService.Getcities();

            return View(searchPeople);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreatePersonViewModel createPeople = new CreatePersonViewModel();
            createPeople.CityList = _peopleService.Getcities();

            return View(createPeople);
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
                _memoryPeople.Create(createPeople);
                return RedirectToAction("Index");
            }

            createPeople.CityList = _peopleService.Getcities();

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
