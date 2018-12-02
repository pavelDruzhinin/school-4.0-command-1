using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecSystem.Data;
using RecSystem.Models;

namespace RecSystem.Controllers
{
    public class SelectedFilmController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelectedFilmController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: SelectedFilm
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Items.ToListAsync());
        //}

        // GET: SelectedFilm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //// GET: SelectedFilm/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: SelectedFilm/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,MovieTitle,ReleaseDate,VideoReleaseDate,Url")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(item);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(item);
        //}

        //// GET: SelectedFilm/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items.FindAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(item);
        //}

        //// POST: SelectedFilm/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,MovieTitle,ReleaseDate,VideoReleaseDate,Url")] Item item)
        //{
        //    if (id != item.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(item);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ItemExists(item.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(item);
        //}

        //// GET: SelectedFilm/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //// POST: SelectedFilm/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var item = await _context.Items.FindAsync(id);
        //    _context.Items.Remove(item);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ItemExists(int id)
        //{
        //    return _context.Items.Any(e => e.ID == id);
        //}
    }
}
