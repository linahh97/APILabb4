using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APILabb4.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        [Required]
        public string HobbyName { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<PersonHobby> PersonHobbies { get; set; }
    }
}
