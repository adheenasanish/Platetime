using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlateTimeApp.Models;
using PlateTimeApp.Repositories;
using PlateTimeApp.ViewModel;

namespace PlateTimeApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class RestaurantProfilesController : Controller
    {
        private readonly PlateTimeContext db;
        private RestaurantProfileRepo repo;

        public RestaurantProfilesController(PlateTimeContext context)
        {
            db = context;
            repo = new RestaurantProfileRepo(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            string userId = db.AspNetUsers
                         .Where(u => u.UserName == userName)
                         .FirstOrDefault().Id;

            RestaurantProfileVM profile = repo.GetProfile(userId);
            return View(profile);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {

            RestaurantProfileVM profile = repo.GetProfile(id);
            return View(profile);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantProfileVM profile)
        {
            repo.Update(profile);
            return RedirectToAction("Index");
        }
    }
}
