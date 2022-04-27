using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    interface IPeopleRepo
    {
        bool Initialize();
        List<Person> All();
        Person Create(string firstName, string lastName, string city, int phone);
        List<Person> GetPersons();
        List<string> Getcities();
        Person GetByID(int id);

        bool Update(Person person);
        bool Delete(Person person);
    }
}
