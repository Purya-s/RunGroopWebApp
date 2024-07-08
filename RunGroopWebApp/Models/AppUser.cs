﻿using System.ComponentModel.DataAnnotations;

namespace RunGroopWebApp.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }

        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public Address? Adress { get; set; }

        public ICollection<Club> clubs { get; set; }
        public ICollection<Race> races { get; set; }
    }
}