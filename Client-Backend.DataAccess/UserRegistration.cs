using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Client_Backend.DataAccess
{
        public class UserRegistration
        {
        [DisplayName("First name")]
        [Required(ErrorMessage = "Please enter your first name."), MaxLength(100)]
        public string FirstName { get; set; }
        [DisplayName("Last Name"), MaxLength(100)]
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [DisplayName("Username"), MaxLength(15)]
        [Required(ErrorMessage = "Please enter your username.")]
        public string UserName { get; set; }
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address."), MaxLength(100)]
        public string EmailAddress { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter a password."), MaxLength(32)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})", ErrorMessage = "Your password must contain at least 1 lowercase character, 1 uppercase character, 1 numeric character, 1 special character and it must be eight characters or longer.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        }
}
