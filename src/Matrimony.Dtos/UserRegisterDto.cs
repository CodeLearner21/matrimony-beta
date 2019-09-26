using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Matrimony.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Firstname is required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required field")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required field")]
        public string Password { get; set; }


        public UserRegisterDto(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
