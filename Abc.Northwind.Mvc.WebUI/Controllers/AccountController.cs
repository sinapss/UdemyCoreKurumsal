using Abc.Northwind.Mvc.WebUI.Entities;
using Abc.Northwind.Mvc.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.Mvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signUInManager;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signUInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signUInManager = signUInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel) 
        {
            if(ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if(result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if(!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(registerViewModel);
                        }
                    }
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(registerViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = _signUInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.Rememberme, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "Invalid login!");
            }
            return View(loginViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signUInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}
