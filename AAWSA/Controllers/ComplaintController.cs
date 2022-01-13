using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Controllers
{
    public class ComplaintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
