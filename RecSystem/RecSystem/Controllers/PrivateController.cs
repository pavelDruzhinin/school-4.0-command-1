using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecSystem.Controllers
{
    public class PrivateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}