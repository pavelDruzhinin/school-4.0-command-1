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
        public class SoccerContext : DbContext
        {
            public DbSet<Rating> Raitings { get; set; }
            public DbSet<Item> Items { get; set; }
        }

        // GET: Main
        [Authorize]
        public async Task<IActionResult> Index()
        {
            SoccerContext db = new SoccerContext();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;



            ////Выбираем строки с таблицы рейтинга где кастид = нашему, потом объединя
            //var result = _context.Ratings.Where(u =>u.CustomerId == userId)
            //    .Join(_context.Items, // второй набор
            //     p => p.ID, // свойство-селектор объекта из первого набора
            //     t => t.ID, // свойство-селектор объекта из второго набора
            //     (p, t) => new { Name = t.MovieTitle, Rating = p.Score}); // результат

            //    return View(await result.ToListAsync());
            var query = await _context.Ratings
                .Include(x => x.Item)
                .Where(x => x.CustomerId == userId)
                 .ToListAsync();

            //var ordersViewModel = query
            //    .Select(qu => new PrivateViewModel
            //    {
            //        ID = 1,

            //        Items = qu.Ratings
            //            .Select(item => new PrivateItemViewModel
            //            {
            //                Title = item.Items.Title,
            //                Score = item.Ratings.Score
            //            }).ToList()
            //    });
            //var query = _context.Items.Join(_context.Ratings,
            //            item => item.ID,
            //            rating => rating.itemID,                        
            //            (item, rating) =>
            //                new { Title = item.MovieTitle, Score = rating.Score , Cust = rating.CustomerId})
            //                .Where(q => q.Cust == userId).ToList();
            //IEnumerable<string> FilmsWithYouScore =
            //    from r in _context.Ratings
            //    join i in _context.Items
            //    on r.ItemID equals i.ID
            //    where r.CustomerId == userId
            //    select r.MovieTitle, r.Score;
            //foreach (string title in FilmsWithYouScore)



            return View(query);
        }
    }

}