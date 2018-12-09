﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecSystem.Data;
using RecSystem.Models;
using RecSystem.ViewModels;

namespace RecSystem.Controllers
{
    [Route("Film")]
    public class SelectedFilmController : Controller
    {
        private readonly ApplicationDbContext _db;
        private UserManager<Customer> _userManager { get; set; }
        private readonly IMemoryCache _cache;

        public SelectedFilmController(ApplicationDbContext db, UserManager<Customer> userManager,
            IMemoryCache memoryCache)
        {
            _db = db;
            _userManager = userManager;
            _cache = memoryCache;
        }

        [HttpGet]
        [Route("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _db.Items.FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            string userId = _userManager.GetUserId(User);
            var rating = await _db.Ratings.FirstOrDefaultAsync(x => x.CustomerId == userId && x.ItemID == id);

            FilmUserViewModel filmViewModel = new FilmUserViewModel
            {
                ID = item.ID,
                MovieTitle = item.MovieTitle,
                ReleaseDate = item.ReleaseDate,
                VideoReleaseDate = item.ReleaseDate,
                Url = item.Url,
                ScoreUser = (rating != null) ? rating.Score : 0,
                IdUser = userId
            };

            return View(filmViewModel);
        }

        [HttpPost]
        [Route("AddScore")]
        public async Task<IActionResult> AddScore(FilmUserViewModel filmViewModel)
        {
            var rating = await _db.Ratings.FirstOrDefaultAsync(x => x.CustomerId == filmViewModel.IdUser && x.ItemID == filmViewModel.ID);

            if (rating == null)
            {
                rating = new Rating
                {
                    CustomerId = filmViewModel.IdUser,
                    ItemID = filmViewModel.ID,
                    Score = filmViewModel.ScoreUser
                };
                _db.Ratings.Add(rating);
                _db.SaveChanges();
            }
            else
            {
                rating.Score = filmViewModel.ScoreUser;
                _db.SaveChanges();
            }
            _cache.Remove("RecommendIdItemList");

            return RedirectToAction("Details", new { id = filmViewModel.ID });
        }

    }
}
