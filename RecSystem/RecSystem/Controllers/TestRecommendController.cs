using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecSystem.Data;
using RecSystem.Models;

namespace RecSystem.Controllers
{
    [Route("test")]
    public class TestRecommendController : Controller
    {
        private readonly Services.RecommendService _recService;
        public ApplicationDbContext _db;

        public TestRecommendController(Services.RecommendService recService, ApplicationDbContext db)
        {
            _recService = recService;
            _db = db;
        }

        [Route("")]
        public IActionResult Index()
        {
            //Закомментировать вызов CreateTestData, если не нужно заполнять БД тестовыми данными
            TestData.CreateTestData(_db);

            List<int> RecommendIdItemList = _recService.GetListRecommendIdItemForUserId("ID-Toby");
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();
            
            return View(RecommendFilmList);
        }
    }
}
