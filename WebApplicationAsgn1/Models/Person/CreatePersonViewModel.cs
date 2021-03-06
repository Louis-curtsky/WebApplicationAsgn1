using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationAsgn1.Models.Person
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Ypour Contact No")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public List<Person> PeopleLists { get; set; }

        public List<string> CityList { get; set; }

        public List<Person> PeopleIndexViewModel()
        {
            PeopleLists = new List<Person>();
            return PeopleLists;
        }
    }
}
