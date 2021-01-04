using HomeEduBackendFinal.Models;
using HomeEduBackendFinal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HomeEduBackendFinal.Extentions.Extention;

namespace HomeEduBackendFinal.Controllers
{

    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or password wrong!!!");
                return View();
            }

            if (user.IsActivated)
            {
                ModelState.AddModelError("", "This account blocked!!!");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Please,try few minutes later");
                return View(login);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password wrong!!!");
                return View();
            }


            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm register)
        {
            if (!ModelState.IsValid) return NotFound();
            AppUser newUser = new AppUser
            {
                UserName = register.UserName,
                Fullname = register.FullName,
               
                Email = register.Email,

            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Admin.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #region CreateRoleManager

        public async Task CreateUserRole()
        {
            if (!(await _roleManager.RoleExistsAsync(Roles.Admin.ToString())))
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
            if (!(await _roleManager.RoleExistsAsync(Roles.Member.ToString())))
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
            if (!(await _roleManager.RoleExistsAsync(Roles.Moderator.ToString())))
                await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Moderator.ToString() });
        }
        #endregion
    }

}
