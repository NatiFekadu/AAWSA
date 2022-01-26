using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAWSA.Models;
using Microsoft.AspNetCore.Identity;
using AAWSA.Areas.Identity.Data;

namespace Microsoft.AspNetCore.Identity
{
    public class AdminController : Controller

    {

        private UserManager<AAWSAUser> userManager;


        public AdminController(UserManager<AAWSAUser> usrMgr)
        {
            userManager = usrMgr;
        }




        [HttpGet]
        public IActionResult Index()
        {

            var users = userManager.Users;
            return View(users);
        }



        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AAWSAUser user)
        {
            if (ModelState.IsValid)
            {
                AAWSAUser appUser = new AAWSAUser
                {
                   
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.PasswordHash);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id)
        {
            AAWSAUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
                return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task <IActionResult> Update (string id,string UserN, string email,Role role_, string password)
        {
            AAWSAUser user = await userManager.FindByIdAsync(id);
            if (user!=null)
            {
                if (!string.IsNullOrEmpty(UserN))
                {
                    user.UserName = UserN;
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty!");
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                    ModelState.AddModelError("", "Email cannot be empty!");
                
                    user.Role = role_;
                if (!string.IsNullOrEmpty(password))
                {
                    // user.PasswordHash =
                        }
                else
                    ModelState.AddModelError("", "Email cannot be empty!");
            }

            return View(user);
        }
    }
}
