using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Client_Backend.Domain
{
    public class UserLogin
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        public string ReturnUrl { get; set; }
    }
}
