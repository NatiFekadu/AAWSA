using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAWSA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AAWSA.Areas.Identity.Data;


namespace AAWSA.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ComplaintDbContext _context;
     //  private readonly UserManager<AAWSAUser> _userManager;

        public ComplaintsController(ComplaintDbContext context)
        {
            _context = context;
        }

        // GET: Complaints
       //[ Authorize(Roles = " Head_Office_Operator")]
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

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .FirstOrDefaultAsync(m => m.id == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // GET: Complaints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Date,FirstName,LastName,Branches,Special_Place_Name,status,HouseNumber,PhoneNumber,Subcity,Woreda,CaseType,Complaint_Type")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Date,FirstName,LastName,Branches,Special_Place_Name,status,HouseNumber,PhoneNumber,Subcity,Woreda,CaseType,Complaint_Type")] Complaint complaint)
        {
            if (id != complaint.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintExists(complaint.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .FirstOrDefaultAsync(m => m.id == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.id == id);
        }
    }
}
