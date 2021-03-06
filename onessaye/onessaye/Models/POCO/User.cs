﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onessaye.Models.POCO
{
    public class User
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(15), Display (Name = "Enter your nickname")]
        public string Nickname { get; set; }
        [Required, MinLength(4), MaxLength(1500), Display(Name = "Enter your password")]
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateRegister { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string DoorNumber { get; set; }
    }
}