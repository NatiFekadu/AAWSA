using AAWSA.Areas.Identity.Data;
using AAWSA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAWSA;
using Microsoft.AspNetCore.Mvc.Rendering;
using AAWSA.Data;
using System.Dynamic;

namespace AAWSA.Controllers
{
    public class TechnicianAssign : Controller
    {
        private ComplaintDbContext _context;


        /*  public TechnicianAssign(ComplaintDbContext context)
          {
              _context = context;
          }

          */
        private  UserManager<AAWSAUser> userManager;

        dynamic mymodel = new ExpandoObject();

        public TechnicianAssign(UserManager<AAWSAUser> usrMgr ,ComplaintDbContext context)
        {
           
            _context = context;
            userManager = usrMgr;
        }


        public IActionResult TechList()
        {

            ViewBag.userId = new SelectList(userManager.Users);
            return View();

        }
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


            var Complaints = from c in _context.Complaints
                             select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                Complaints = Complaints.Where(c => c.LastName.Contains(searchString)
                                       || c.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Complaints = Complaints.OrderByDescending(c => c.FirstName);
                    break;
                case "Date":
                    Complaints = Complaints.OrderBy(c => c.Date);
                    break;
                case "date_desc":
                    Complaints = Complaints.OrderByDescending(c => c.Date);
                    break;
                default:
                    Complaints = Complaints.OrderBy(c => c.LastName);
                    break;
            }
             var user = await userManager.GetUserAsync(User);
            // var userrs = from u in userManager.Users
            //             select u;

            
            
          

           

            ViewBag.curBranche =user.Branches.ToString();
            ViewData["users"] = userManager.Users;

           // var users = new SelectList(userManager.Users);

            

         /*   if (user.Role.ToString() == "Technician"  && user.Branches.ToString() == ViewBag.curBranche)
            {
                ViewBag.userId = new SelectList( user.Role.ToString() == "Technician" && user.Branches.ToString() == ViewBag.curBranche);
            }

            
            */

            //ViewBag.Br = CurrentuserBranche.ToString();

            int pageSize = 15;
            return View(await PaginatedList<Complaint>.CreateAsync(Complaints.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


    } 
}
      