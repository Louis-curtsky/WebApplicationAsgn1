using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    public class PeopleService : IPeopleService
    {
        static List<Person> PeopleSearch = new List<Person>();
        static List<Person> peopleStorage = new List<Person>();

        IMemoryPeopleRepo _PeopleRepo;
 
        public List<Person> All()
        {
            return _PeopleRepo.peopleStorage;
        }

        public Person Add(string firstName, string lastName, string city, int phone)
        {
            return _PeopleRepo.Create(firstName, lastName, city, phone);
        }
        public bool Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            return _PeopleRepo.GetByID(id);

        }

        public bool Remove(int id)
        {


            return true;
        }

        public List<Person> Search(string searches)
        {
//            List<Person> searchPerson = new List<Person>();
            string[] searchList = searches.Split("|");
            PeopleSearch.Clear();
            foreach (Person person in peopleStorage)
            {
                if (person.FirstName == searchList[0] || person.LastName == searchList[1]
                      || person.City == searchList[2])
                {
                    PeopleSearch.Add(person);
                }

            }

            return PeopleSearch;
        }

        public List<Person> SearchResult()
        {
            return PeopleSearch;
         }
    }
}
