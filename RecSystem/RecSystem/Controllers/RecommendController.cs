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
    [Route("rec")]
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
        [Route("GetRecomget")]
        [Authorize]
        public IActionResult GetRecom(string userId)
        {
            if (!_cache.TryGetValue("RecommendIdItemList", out List<int> RecommendIdItemList))
            {
                RecommendIdItemList = _recService.GetListRecommendIdItemForUserId(userId);
                _cache.Set("RecommendIdItemList", RecommendIdItemList, TimeSpan.FromMinutes(10));
            }
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();

            return View("Index", new RecommendFilmsViewModel(RecommendFilmList));
        }

    }
}
