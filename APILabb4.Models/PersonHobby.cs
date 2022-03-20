using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APILabb4.Models
{
    public class PersonHobby
    {
        [Key]
        public int PersonHobbyId { get; set; }
        [Required]
        public int HobbyId { get; set; }
        [Required]
        public int PersonId { get; set; }
        public string? WebLink { get; set; }

        public Hobby Hobby { get; set; }
        public Person Person { get; set; }
    }
}
