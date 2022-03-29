using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace APILabb4.Models
{
    [Serializable]
    public class PersonHobby
    {
        [Key]
        public int PersonHobbyId { get; set; }
        [Required]
        public int HobbyId { get; set; }
        [Required]
        public int PersonId { get; set; }
        public string? WebLink { get; set; }

        [JsonIgnore]
        public Hobby Hobby { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
    }
}
