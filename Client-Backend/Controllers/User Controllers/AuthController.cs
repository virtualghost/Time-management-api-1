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

        /*[HttpGet]
        public ViewResult Register()
        {
            return StatusCode(200);
        }
        */

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
            return StatusCode(202);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return StatusCode(205);
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl = "")
        {
            var model = new UserLogin { ReturnUrl = ReturnUrl };
            return StatusCode(200); // "no content, refresh; refresh client view
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
            return StatusCode(403); // implicit failure, failed login, includes bad credentials/permissions
        }
    }
}
