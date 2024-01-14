﻿using System.ComponentModel.DataAnnotations;

namespace TokenBasedAuthentication.Models.Domain
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
