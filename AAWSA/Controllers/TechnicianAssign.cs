using AAWSA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Controllers
{
    public class TechnicianAssign : Controller
    {
        private ComplaintDbContext _context;

        public TechnicianAssign(ComplaintDbContext context)
        {
            _context = context;
        }
        

        // private readonly UserManager<AAWSAUser> _userManager;



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
            //  var user = await _userManager.GetUserAsync(User);
            // var CurrentuserBranche =user.Branches;

            //ViewBag.Br = CurrentuserBranche.ToString();

            int pageSize = 5;
            return View(await PaginatedList<Complaint>.CreateAsync(Complaints.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

    } 
}
      