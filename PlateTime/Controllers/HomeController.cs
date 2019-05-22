using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlateTimeApp.Models;

namespace PlateTimeApp.Controllers
{
    public class HomeController : Controller
    {
        private PlateTimeContext db;

        public HomeController(PlateTimeContext db)
        {
            this.db = db;
            Seeder seeder = new Seeder(db);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessApi()
        {

            return View();
        }
        public IActionResult Api()
        {
            return View();
        }

        public IActionResult ApiGuide() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
