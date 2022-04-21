using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    interface IPeopleRepo
    {
        List<Person> GetPersons();
        List<string> Getcitys();
        Person GetByID(int id);

        bool Update(Person person);
        bool Delete(Person person);
    }
}
