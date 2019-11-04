using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Backend.DataAccess;

namespace Client_Backend.Controllers.User_Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRegistration UserRegistrationModel)
        {
            User user = new User
            {
                ID = UserRegistrationModel.ID,
                FirstName = UserRegistrationModel.FirstName,
                LastName = UserRegistrationModel.LastName,
                UserName = UserRegistrationModel.UserName,
                EmailAddress = UserRegistrationModel.EmailAddress
            };
            if (UserRegistrationModel.Password == UserRegistrationModel.ConfirmPassword)
            {
                user.Password = UserRegistrationModel.Password;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //Need to find a way to initialize the database variable
                }
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id)
        {
            //Update logic
        }



        
        }
    }
}
