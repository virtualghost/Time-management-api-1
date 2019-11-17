using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_Backend.Domain;
using Microsoft.AspNetCore.Identity;

namespace Client_Backend.Controllers.UserController
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
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

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return StatusCode(205);
        }

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new UserLogin { ReturnUrl = returnUrl };
            return StatusCode(200); // "no content, refresh; refresh client view
        }

        [HttpPost("Login")]
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
