using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Backend.DataAccess;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Client_Backend.Controllers.User_Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            Debug.WriteLine("Hello World");
            _userManager = userManager;
            _signInManager = signInManager;
            Debug.WriteLine("Hello Worlds");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName
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

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return StatusCode(205);
        }

        // [HttpGet("login")]
        // public IActionResult Login(string ReturnUrl = "")
        // {
        //     var model = new UserLogin { ReturnUrl = ReturnUrl };
        //     return StatusCode(200); // "no content, refresh; refresh client view
        // }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if(result.Succeeded)
                {
                    return Ok();
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return StatusCode(403); // implicit failure, failed login, includes bad credentials/permissions
        }
    }
}
