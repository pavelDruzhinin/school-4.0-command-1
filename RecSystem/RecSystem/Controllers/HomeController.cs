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
    public class HomeController : Controller
    {
        private readonly Services.RecommendService _myService;
        public ApplicationDbContext _db;

        public HomeController(Services.RecommendService myService, ApplicationDbContext db)
        {
            _myService = myService;
            _db=db;
        }

        
        public IActionResult Index()
        {
            /*
            * Не забыть удалить при merge
            * Внимание!!! Перед заполнением тестовыми данными таблицы: Users, Items и Rating будут очищены 
            */
            TestData.CreateTestData(_db);
            List<int> RecommendIdItemList = _myService.GetListRecommendIdItemForUserId("ID-Toby");

            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
