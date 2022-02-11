using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAWSA.Models;
using Microsoft.AspNetCore.Identity;
using AAWSA.Areas.Identity.Data;
using Microsoft.AspNet.Identity;
using AAWSA.Data;
using AAWSA;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["currentFilter"] = searchString;


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            var userrs = from u in userManager.Users
                                       select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                userrs = userrs.Where(u => u.LastName.Contains(searchString)
                                       || u.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    userrs = userrs.OrderBy(u => u.FirstName);
                    
                    break;
                case "Date":
                    userrs = userrs.OrderBy(u => u.BirthDate);
                    break;
                case "date_desc":
                    userrs = userrs.OrderBy(u => u.BirthDate);
                    break;
                default:
                    userrs = userrs.OrderBy(u => u.LastName);
                    break;
            }

            int pageSize = 6;
            

            return View( await PaginatedList<AAWSAUser>.CreateAsync(userrs.AsNoTracking(), pageNumber ?? 1, pageSize));
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
    private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AAWSAUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}
