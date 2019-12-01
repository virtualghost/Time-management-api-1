using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Client_Backend.DataAccess
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
