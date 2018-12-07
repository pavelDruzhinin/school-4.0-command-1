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
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> RecommendIdItemList = _recService.GetListRecommendIdItemForUserId(userId);
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();
            sw.Stop();

            ViewBag.Message = "Список рекомендаций";
            ViewBag.Time = (sw.ElapsedMilliseconds / 100.0).ToString();
            return View("Index", RecommendFilmList);
        }

        [Route("getbd/{userId}")]
        public IActionResult GetRecomBD(string userId)
        {
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int> RecommendIdItemList = _recService.GetListRecommendIdItemForUserIdBD(userId);
            List<Item> RecommendFilmList = _db.Items.Where(item => RecommendIdItemList.Contains(item.ID)).ToList();
            sw.Stop();

            ViewBag.Message = "Список рекомендаций";
            ViewBag.Time = (sw.ElapsedMilliseconds / 100.0).ToString();
            return View("Index", RecommendFilmList);
        }
    }
}
