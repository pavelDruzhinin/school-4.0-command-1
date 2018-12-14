using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecSystem.Data;
using RecSystem.Models;
using RecSystem.ViewModels;

namespace RecSystem.Controllers
{
    public class PrivateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivateController(ApplicationDbContext context)
        {
            _context = context;
        }
        public class FilmContext : DbContext
        {
            public DbSet<Rating> Raitings { get; set; }
            public DbSet<Item> Items { get; set; }
        }

        // GET: Private
        [Authorize]
        public async Task<IActionResult> Index()
        {
            FilmContext db = new FilmContext();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var query = await _context.Ratings
                .Include(x => x.Item)
                .Where(x => x.CustomerId == userId)           
                 .ToListAsync();

          return View(query);
        }
    }
    
}