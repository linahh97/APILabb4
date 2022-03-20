using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APILabb4.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<PersonHobby> PersonHobbies { get; set; }
    }
}
