using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    public class IMemoryPeopleRepo : IPeopleRepo
    {
        static int idCounter = 0;
        static List<Person> peopleStorage = new List<Person>();
        static List<string> cityStorage = new List<string>();

        public void Initialize()
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
//                Person storePerson = new Person(++idCounter, "Louis", "Lim", "Växjö", 0765551111);
                peopleStorage.Add(new Person() { Id=++idCounter,FirstName="Louis", LastName="Lim", City= "Växjö", Phone= 0765551111 });
                peopleStorage.Add(new Person() {Id=++idCounter, FirstName="Michael", LastName="Kent", City="Gothenburg", Phone= 0733338888 });
                peopleStorage.Add(new Person() {Id=++idCounter, FirstName = "Åsa", LastName = "Jason", City = "Malmö", Phone = 0721231234 });
            }
        }
       
        public Person Create(CreatePersonViewModel person)
        {
            Person storePerson = new Person(++idCounter, person.FirstName, person.LastName, person.City, person.Phone);
            peopleStorage.Add(storePerson);
            return storePerson;
        }

        public List<Person> GetPersons()
        {
            throw new NotImplementedException();
        }

        public List<string> Getcitys()
        {
            throw new NotImplementedException();
        }

        public Person GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
