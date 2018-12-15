using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RecSystem.Data;
using RecSystem.Models;
using RecSystem.ViewModels;

namespace RecSystem.Controllers
{
    public class RecommendController : Controller
    {
        private readonly Services.RecommendService _recService;
        public ApplicationDbContext _db;
        private readonly IMemoryCache _cache;
        private UserManager<Customer> _userManager { get; set; }

        public RecommendController(Services.RecommendService recService, ApplicationDbContext db,
            IMemoryCache memoryCache, UserManager<Customer> userManager)
        {
            _recService = recService;
            _db = db;
            _cache = memoryCache;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            if (!_cache.TryGetValue(String.Concat("RecommendIdItemList", userId), out List<int> RecommendIdItemList))
            {
                RecommendIdItemList = _recService.GetListRecommendIdItemForUserId(userId);
                _cache.Set(String.Concat("RecommendIdItemList", userId), RecommendIdItemList, TimeSpan.FromMinutes(10));
            }
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();

            return View(new RecommendFilmsViewModel(RecommendFilmList));
        }

    }
}
