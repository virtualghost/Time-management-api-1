using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Client_Backend.Domain
{
    public class User : IdentityUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string UserName { get; set; }
        public string EmailAddress { get; set; }
        
        //public string PasswordSalt { get; set; }
        //public string PasswordHash { get; set; }
        public int RelatedAccountID { get; set; }
        public bool IsEmailVerified { get; set; }
    }
}
