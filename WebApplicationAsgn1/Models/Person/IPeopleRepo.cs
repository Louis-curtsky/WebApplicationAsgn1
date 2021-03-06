using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models.Person
{
    public interface IPeopleRepo
    {
        bool Initialize();
        List<Person> All();
        List<PersonViewModel> GetList();
        Person Create(string firstName, string lastName, string city, string phone);
        List<Person> GetPersons(string firstName, string lastName, string city, string phone);
        List<string> Getcities();
        List<Person> GetByID(int id);

        List<Person> Search(string firstName, string lastName, string city);
        Person Update(Person person);
        bool Delete(int id);
    }
}
