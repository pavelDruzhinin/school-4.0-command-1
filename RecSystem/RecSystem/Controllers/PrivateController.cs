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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //List<object> result = new List<object>();
            //List<string> result = new List<string>();
            var query = await _context.Ratings
                                      .Include(x => x.Item)
                                      .Where(x => x.CustomerId == userId)
                                      //.Select(x => new
                                      //{
                                      //    Title = x.Item.MovieTitle,
                                      //    Rating = x.Score
                                      //})
                                      //.Select(x => x.Item.MovieTitle ; x=> x.Rating)
                                      .ToListAsync();
            //foreach (var i in query) {
            //    result.Add(i);

            //}
            
            ////string result = "";
            ////foreach (var x in query)
            ////    result += $"{x.Title} , {x.Rating} \n";
                
            

            return View(new RatedFilmsViewModel(query));
        }
    }

}