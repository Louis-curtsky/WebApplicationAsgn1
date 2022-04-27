using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    public class IMemoryPeopleRepo : IPeopleRepo
    {
        public bool Initialized = false;
        static int idCounter = 0;
        public List<Person> peopleStorage = new List<Person>();
        public List<string> cityStorage = new List<string>();

        public bool Initialize()
        {
//            List<Person> returnList = new List<Person>();
            if (peopleStorage.Count==0)
            {
                // Below Never put outside of if loop
//                Person storePerson = new Person(++idCounter, "Louis", "Lim", "Växjö", 0765551111);
                peopleStorage.Add(new Person() { Id=++idCounter,FirstName="Louis", LastName="Lim", City= "Växjö", Phone= 0765551111 });
                peopleStorage.Add(new Person() {Id=++idCounter, FirstName="Michael", LastName="Kent", City="Gothenburg", Phone= 0733338888 });
                peopleStorage.Add(new Person() {Id=++idCounter, FirstName = "Åsa", LastName = "Jason", City = "Malmö", Phone = 0721231234 });
                Initialized = true;

  //              returnList = peopleStorage;
            }
            return Initialized;
        }

        public List<Person> All()
        {
            return peopleStorage;
        }
        public Person Create(string firstName, string lastName, string city, int phone)
        {
            Person person = new Person(++idCounter, firstName, lastName, city, phone);
            peopleStorage.Add(
                person);
                return person;
        }

        public List<Person> GetPersons()
        {
            return peopleStorage;
        }

        public List<string> Getcities()
        { 
            if (cityStorage.Count == 0)
            {
                cityStorage.Add("Stockholm");
                cityStorage.Add("Gothenburg");
                cityStorage.Add("Malmö");
                cityStorage.Add("Uppsala");
                cityStorage.Add("Växjö");
                cityStorage.Add("Västerås");
            }
            return cityStorage;
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
