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

        public RecommendController(Services.RecommendService recService, ApplicationDbContext db, IMemoryCache memoryCache)
        {
            _recService = recService;
            _db = db;
            _cache = memoryCache;
        }

        [Route("get")]
        [Authorize]
        public IActionResult GetRecom()
        {
            if (!_cache.TryGetValue("RecommendIdItemList", out List<int> RecommendIdItemList))
            {
                RecommendIdItemList = _recService.GetListRecommendIdItemForUserId("id-user");
                _cache.Set("RecommendIdItemList", RecommendIdItemList, TimeSpan.FromMinutes(10));
            }
                        
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();

            return View("Index", new RecommenfFilmViewModel(RecommendFilmList));
        }

    }
}
