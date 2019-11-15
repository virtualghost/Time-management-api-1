using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Backend.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace Client_Backend.Controllers.User_Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public AuthController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if(ModelState.IsValid)
            {
                var user = new User { 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    EmailAddress = model.EmailAddress
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "")
        {
            var model = new UserLogin { ReturnUrl = ReturnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    } else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }

        /*[HttpGet]
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
        */
    }
}
