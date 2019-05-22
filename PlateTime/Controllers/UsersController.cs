using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlateTimeApp.Repositories;
using PlateTimeApp.ViewModel;
using PlateTimeApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PlateTimeApp.Controllers
{

    [Authorize(Roles = "Admin, Member")]
    public class UsersController : Controller
    {
        private PlateTimeContext db;
        private UserProfileVMRepo repo;
        //public new object ViewBag { get; }

        public UsersController(PlateTimeContext db)
        {
            this.db = db;
            repo = new UserProfileVMRepo(db);
        }

        
        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;
            string ids = db.AspNetUsers
                         .Where(x => x.Email == userName)
                         .FirstOrDefault().Id;

            var plateTimeContext = db.PlateTime
                                    .Include(p => p.Restaurant)
                                    .Include(p => p.RestaurantGoer)
                                    .Where(p => p.RestaurantGoer.UserId == ids);

            return View(await plateTimeContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(UserProfileVM upvm)
        {
            AspNetUsers aspuser = new AspNetUsers
            {
                UserName = upvm.aspNetUsers.UserName

            };

            RestaurantGoer rg = new RestaurantGoer
            {
                Name = upvm.restaurantGoer.Name,
                PriceCategory = upvm.restaurantGoer.PriceCategory

            };

            db.SaveChanges();

            return RedirectToAction("Index", upvm.aspNetUsers.Id);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            UserProfileVM profile = new UserProfileVM();

            int resid = 0;
            string name = "";
            var priceCategory = 0;
            string userName = HttpContext.User.Identity.Name;

            string ids = db.AspNetUsers.Where(x => x.Email == userName)
                          .FirstOrDefault().Id;

            int restaurantGoerId = db.RestaurantGoer
                                     .Where(r => r.UserId == ids)
                                     .Select(r => r.Id).FirstOrDefault();
           
            if(restaurantGoerId != 0)
            {
                profile = repo.GetProfile(ids);

                List<RestaurantGoer> data = db.RestaurantGoer
                                           .Where(r => r.UserId == ids).ToList();

                foreach (var items in data)
                {
                    name = items.Name;
                    priceCategory = Convert.ToInt32(items.PriceCategory);
                    resid = items.Id;
                }
               
                var restaurantId = db.RestaurantGoerRestaurant
                                     .Where(rgr => rgr.RestaurantGoerId == resid)
                                     .Select(rgr => rgr.RestaurantId).FirstOrDefault();

                var foodCategoryid = db.RestaurantGoerFoodCategory
                                       .Where(rg => rg.RestaurantGoerId == resid)
                                       .Select(rg => rg.FoodCategoryId).FirstOrDefault();

                var foodcategoryName = db.FoodCategory
                                         .Where(fc => fc.Id == foodCategoryid)
                                         .Select(fc => fc.Name).FirstOrDefault();

                var restaurantName = db.Restaurant.Where(rn => rn.Id == restaurantId)
                                                  .Select(rn => rn.Name)
                                                  .FirstOrDefault();

                ViewBag.RestaurantGoerName = name;
                ViewData["PriceCategory"] = priceCategory.ToString();
                ViewData["id"] = resid;
                ViewData["RestaurantName"] = restaurantName;
                ViewData["foodCategory"]  = foodcategoryName;
                ViewBag.count = 1;

                IList<Restaurant> restaurantList = new List<Restaurant>();
                restaurantList = db.Restaurant.Where(r => r.Name != null).ToList();

                var preRestaurantIdList = restaurantList.Select(r =>
                                          new SelectListItem { Value = r.Name, Text = r.Name })
                                          .ToList();

                var RestaurantIdList = new SelectList(preRestaurantIdList, "Value", "Text");
                ViewBag.ReataurantIdSelectList = RestaurantIdList;


                IList<FoodCategory> foodCategoryList = new List<FoodCategory>();
                foodCategoryList = db.FoodCategory.Where(f => f.Name != null).ToList();

                var preIdList = foodCategoryList.Select(r =>
                                new SelectListItem { Value = r.Name, Text = r.Name })
                               .ToList();

                var IdList = new SelectList(preIdList, "Value", "Text");

                ViewBag.IdSelectList = IdList;

                ViewBag.Name = foodCategoryList;

                var prices = new SelectListItem[10];

              
                int j = 0;
                for (int i = 10; i <= 100; i = i + 10)
                {
                    prices[j++] = new SelectListItem() { Value = i.ToString(), Text = "$" + i };


                }

                ViewBag.Price = prices;

                ViewData["restaurantId"] = new SelectList(db.Restaurant, "Name");

                ViewData["foodCategoryId"] = new SelectList(db.FoodCategory, "Name");

            }
            else
            {
                var allCategories = db.FoodCategory.ToList();
                var checkBoxListItems = new List<CheckBoxListItem>();
                foreach (var category in allCategories)
                {
                    checkBoxListItems.Add(new CheckBoxListItem()
                    {
                        ID = category.Id,
                        Display = category.Name,
                        IsChecked = false
                    });
                }
                profile.FoodCategoryCheckboxes = checkBoxListItems;

                IList<Restaurant> restaurantList = new List<Restaurant>();
                restaurantList = db.Restaurant.Where(r => r.Name != null).ToList();
                var preRestaurantIdList = restaurantList.Select(r =>
                                         new SelectListItem { Value = r.Name, Text = r.Name })
                                        .ToList();

                var RestaurantIdList = new SelectList(preRestaurantIdList, "Value", "Text");
                ViewBag.ReataurantIdSelectList = RestaurantIdList;


                IList<FoodCategory> foodCategoryList = new List<FoodCategory>();
                foodCategoryList = db.FoodCategory.Where(f => f.Name != null).ToList();

                var preIdList = foodCategoryList.Select(r =>
                                new SelectListItem { Value = r.Name, Text = r.Name })
                               .ToList();

                var IdList = new SelectList(preIdList, "Value", "Text");

                ViewBag.IdSelectList = IdList;

                ViewBag.Name = foodCategoryList;

                var prices = new SelectListItem[10];

      
                int j = 0;
                for (int i = 10; i <= 100; i = i + 10)
                {
                    prices[j++] = new SelectListItem() { Value = i.ToString(), Text = "$" + i };
                }

                ViewBag.Price = prices;

                ViewData["restaurantId"] = new SelectList(db.Restaurant, "Name");

                ViewData["foodCategoryId"] = new SelectList(db.FoodCategory, "Name");

                //return View();

            }

            return View(profile);

        }

        [HttpPost]
        public ActionResult Edit(UserProfileVM upVM)
        {
            string userName = HttpContext.User.Identity.Name;
            string ids = db.AspNetUsers
                          .Where(x => x.Email == userName)
                          .FirstOrDefault().Id;
            UserProfileVMRepo upvmRepo = new UserProfileVMRepo(db);
            upvmRepo.Update(ids,upVM);
            return RedirectToAction("Index");
        }
    }
}