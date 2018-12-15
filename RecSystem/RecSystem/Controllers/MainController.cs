using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecSystem.Data;
using RecSystem.Models;
using RecSystem.ViewModels;

namespace RecSystem.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        public  async Task<IActionResult> Index(int page = 1, string searchString = null)

        {
            IQueryable<Item> source = _context.Items;
            int pageSize = 30;
            var movies = from m in _context.Items
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieTitle.Contains(searchString));

                var c = await movies.CountAsync();
                var part = await movies.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                PageViewModel pageViewMode = new PageViewModel(c, page, pageSize);
                IndexViewModel view = new IndexViewModel
                {
                    PageViewModel = pageViewMode,
                    Items = part
                };
                return View(view);
            }
            else
            {
                var count = await source.CountAsync();
                var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    Items = items
                };
                return View(viewModel);
            }

            
           
        }
        public IActionResult Top()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

    }
}
