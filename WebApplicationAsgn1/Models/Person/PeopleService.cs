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
        static List<string> cityStorage = new List<string>();


        public List<string> Getcities()
        {
            return cityStorage;
        }
 
        public List<Person> All()
        {
            return peopleStorage;
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            foreach (Person person in peopleStorage)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;

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
