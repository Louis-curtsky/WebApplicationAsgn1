using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAsgn1.Models.Person
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName{ get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Contact Number")]
        public int Phone { get; set; }
        public Person()
        { }

        public Person(string firstName, string lastName, string city, int phone)
        {
            FirstName=firstName;
            LastName = lastName;
            City = city;
            Phone = phone;
        }
        public Person(int id, string firstName, string lastName, string city, int phone): this (firstName,lastName,city,phone)
        {
            Id = id;
        }
    }
}
