using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public RecommendController(Services.RecommendService recService, ApplicationDbContext db)
        {
            _recService = recService;
            _db = db;
        }

        [Route("get")]
        [Authorize]
        public IActionResult GetRecom()
        {
            List<int> RecommendIdItemList = _recService.GetListRecommendIdItemForUserId("Id-user");
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();

            return View("Index", new RecommenfFilmViewModel(RecommendFilmList));
        }

    }
}
