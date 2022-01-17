using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAWSA.Models;
using Microsoft.AspNetCore.Identity;
using AAWSA.Areas.Identity.Data;

namespace AAWSA.Controllers
{
    public class AdminController : Controller

    {

        private UserManager<AAWSAUser> userManager;

        public AdminController(UserManager<AAWSAUser> usrMgr)
        {
            userManager = usrMgr;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
