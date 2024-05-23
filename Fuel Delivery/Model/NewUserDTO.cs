﻿using System.ComponentModel.DataAnnotations;

namespace Fuel_Delivery.Model
{

    public class LoginUserDTO
    {
        [Required]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone nember")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class NewUserDTO : LoginUserDTO
    {
        [Required]
        public string Username { get; set; }

        public ICollection<string> Role { get; set; }

    }
}
