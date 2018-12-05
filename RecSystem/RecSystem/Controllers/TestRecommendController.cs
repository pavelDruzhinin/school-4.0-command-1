using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecSystem.Data;
using RecSystem.Data.Import;
using RecSystem.Models;

namespace RecSystem.Controllers
{
    [Route("rec")]
    public class TestRecommendController : Controller
    {
        private readonly Services.RecommendService _recService;
        public ApplicationDbContext _db;

        public TestRecommendController(Services.RecommendService recService, ApplicationDbContext db)
        {
            _recService = recService;
            _db = db;
        }

        [Route("import")]
        public IActionResult Import()
        {
            ImportData.ImportDataFromCSV(_db);
            List<Item> DataList = _db.Items.Take(5).ToList();

            ViewBag.Message = "Данные успешно загружены";
            return View("Index", DataList);
        }

        [Route("test")]
        public IActionResult CreateTestData()
        {
            ImportData.CreateTestData(_db);
            List<Item> DataList = _db.Items.Take(5).ToList();

            ViewBag.Message = "Данные успешно загружены";
            return View("Index", DataList);
        }

        [Route("get/{userId}")]
        public IActionResult GetRecom(string userId)
        {
            List<int> RecommendIdItemList = _recService.GetListRecommendIdItemForUserId(userId);
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();

            ViewBag.Message = "Список рекомендаций";
            return View("Index", RecommendFilmList);
        }
    }
}
