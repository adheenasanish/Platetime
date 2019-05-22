using PlateTimeApp.ViewModel;
using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlateTimeApp.Repositories
{
    public class UserProfileVMRepo
    {
        private PlateTimeContext db;
        public UserProfileVMRepo(PlateTimeContext db)
        {
            this.db = db;
        }

        public UserProfileVM GetProfile(string id)
        {
            AspNetUsers user = db.AspNetUsers
                                  .Where(u => u.Id == id)
                                  .FirstOrDefault();

            RestaurantGoer newGoers = db.RestaurantGoer
                                       .Where(rg => rg.UserId == id)
                                       .FirstOrDefault();

            int resGoerId = db.RestaurantGoer
                               .Where(r => r.UserId == id)
                               .Select(r => r.Id).FirstOrDefault();

            ICollection<FoodCategory> newCategory = db.RestaurantGoerFoodCategory
                                                      .Where(f => f.RestaurantGoerId == resGoerId)
                                                      .Select(f => f.FoodCategory).Distinct().ToList();

            ICollection<Restaurant> newRestaurant = db.RestaurantGoerRestaurant
                                                      .Where(r => r.RestaurantGoerId == resGoerId)
                                                      .Select(r => r.Restaurant).Distinct().ToList();

            var allCategories = db.FoodCategory.ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var category in allCategories)
            {
                bool IsChecked = false;
                foreach (var c in newCategory)
                {
                    if (c.Id == category.Id)
                    {
                        IsChecked = true;
                        break;
                    }
                }

                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    ID = category.Id,
                    Display = category.Name,
                    IsChecked = IsChecked
                });
            }

            List<SelectListItem> priceCategoryDropdownList
                = new PriceCategoryDropdownBuilder().priceCategories;

            foreach (var c in priceCategoryDropdownList)
            {
                if (c.Value == newGoers.PriceCategory.ToString())
                {
                    c.Selected = true;
                    break;
                }
            }

            UserProfileVM profile = new UserProfileVM()
            {
                aspNetUsers = user,
                restaurantGoer = newGoers,
                foodCategoryList = newCategory,
                restaurantList = newRestaurant,
                foodCategories = newCategory,
                FoodCategoryCheckboxes = checkBoxListItems,
                PriceCategory = newGoers.PriceCategory,
                PriceCategoryList = priceCategoryDropdownList

            };
            return profile;
        }

        public bool Update(string id,UserProfileVM upVM)
        {
            RestaurantGoer restaurantGoer = db.RestaurantGoer
                                              .Where(r => r.UserId == id)
                                              .FirstOrDefault();

            if (restaurantGoer != null)
            {
                restaurantGoer.Name = upVM.Name;
                //restaurantGoer.PriceCategory = upVM.price_category;
                restaurantGoer.UserId = id;
                db.SaveChanges();
            }
            else
            {
                RestaurantGoer restaurantGoers = new RestaurantGoer();
                restaurantGoers.UserId = id;
                restaurantGoers.Name = upVM.Name;
                //restaurantGoers.PriceCategory = upVM.price_category;
                db.Add(restaurantGoers);
                db.SaveChanges();

            }

            var restaurantgoerId = db.RestaurantGoer
                                     .Where(r => r.UserId == id)
                                     .FirstOrDefault();

            var foodCategoryId = db.FoodCategory
                                   .Where(f => f.Name == upVM.foodCategoryName)
                                   .FirstOrDefault();

            //RestaurantGoerFoodCategory restaurantGoerFoodCategory = new RestaurantGoerFoodCategory();
            //restaurantGoerFoodCategory.FoodCategoryId = foodCategoryId.Id;
            //restaurantGoerFoodCategory.RestaurantGoerId = restaurantgoerId.Id;
            //db.Add(restaurantGoerFoodCategory);
            //db.SaveChanges();

            var restaurantId = db.Restaurant
                                 .Where(r => r.Name == upVM.RestaurantName)
                                 .FirstOrDefault();

            RestaurantGoerRestaurant restaurantGoerRestaurant = new RestaurantGoerRestaurant();
            restaurantGoerRestaurant.RestaurantGoerId = restaurantgoerId.Id;
            restaurantGoerRestaurant.RestaurantId = restaurantId.Id;
            db.Add(restaurantGoerRestaurant);
            db.SaveChanges();

            foreach (var checkbox in upVM.FoodCategoryCheckboxes)
            {
                if (checkbox.IsChecked)
                {
                    RestaurantGoerFoodCategory entry = new RestaurantGoerFoodCategory()
                    {
                        FoodCategoryId = checkbox.ID,
                        RestaurantGoerId = restaurantGoer.Id
                    };
                    db.Add(entry);
                    db.SaveChanges();
                }
                else
                {
                    ICollection<RestaurantGoerFoodCategory> entries = db.RestaurantGoerFoodCategory
                                        .Where(f => f.RestaurantGoerId == restaurantGoer.Id && f.FoodCategoryId == checkbox.ID)
                                        .Distinct().ToList();
                    foreach (var entry in entries)
                    {
                        db.RestaurantGoerFoodCategory.Remove(entry);
                        db.SaveChanges();
                    }
                }
            }

            PriceCategoryDropdownBuilder helper = new PriceCategoryDropdownBuilder();
            upVM.PriceCategory = helper.convertType(upVM.PriceCategoryString);
            if (upVM.PriceCategory != null)
            {
                restaurantGoer.PriceCategory = upVM.PriceCategory;
                db.SaveChanges();
            }

            return true;
        }
    }
   
}
