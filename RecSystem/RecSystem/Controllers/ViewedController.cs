using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecSystem.Data;

namespace RecSystem.Controllers
{
    public class ViewedController : Controller
    {
        private ApplicationDbContext _context;

        public ViewedController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("/viewed/cust")]
        public async Task<IActionResult> Index(String id)
        {

            return View(await _context.Items.ToListAsync());
        }
    }
}
