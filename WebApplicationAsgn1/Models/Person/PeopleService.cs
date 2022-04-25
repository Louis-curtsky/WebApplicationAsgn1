using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    public class PeopleService : IPeopleService
    {
        static int idCounter = 0;
        static List<Person> PeopleSearch = new List<Person>();
        static List<Person> peopleStorage = new List<Person>();
        static List<string> cityStorage = new List<string>();
        public PeopleService()
        {
           if (cityStorage.Count == 0)
            {
                cityStorage.Add("Stockholm");
                cityStorage.Add("Gothenburg");
                cityStorage.Add("Malmö");
                cityStorage.Add("Uppsala");
                cityStorage.Add("Växjö");
                cityStorage.Add("Västerås");

                // Below Never put outside of if loop
            peopleStorage.Add(new Person() { Id = idCounter++, FirstName = "Louis", LastName = "Lim", City = "Växjö", Phone = 0765551111 });
            peopleStorage.Add(new Person() { Id = idCounter++, FirstName = "Michael", LastName = "Kent", City = "Gothenburg", Phone = 0733338888 });
            peopleStorage.Add(new Person() { Id = idCounter++, FirstName = "Åsa", LastName = "Jason", City = "Malmö", Phone = 0721231234 });
            }
        }

        public List<string> Getcities()
        {
            return cityStorage;
        }
        public Person Create(CreatePersonViewModel addPerson)
        {
            Person person = new Person { 
                Id = idCounter++, 
                FirstName = addPerson.FirstName, 
                LastName = addPerson.LastName,
                Phone = addPerson.Phone,
                City = addPerson.City
            };
            peopleStorage.Add(person);
            return person;
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
