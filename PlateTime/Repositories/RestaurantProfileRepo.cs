using Microsoft.AspNetCore.Mvc.Rendering;
using PlateTimeApp.Models;
using PlateTimeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Repositories
{
    public class RestaurantProfileRepo
    {
        private PlateTimeContext db;

        public RestaurantProfileRepo(PlateTimeContext db)
        {
            this.db = db;
        }
        public RestaurantProfileVM GetProfile(string id)
        {
            AspNetUsers user = db.AspNetUsers
                                  .Where(u => u.Id == id)
                                  .FirstOrDefault();

            Restaurant restaurant = db.Restaurant
                                       .Where(r => r.UserId == id)
                                       .FirstOrDefault();

            if (restaurant == null)
            {
                RestaurantProfileVM emptyProfile = new RestaurantProfileVM()
                {
                    UserId = id
                };
                return emptyProfile;
            }

            ICollection<FoodCategory> foodCategories = db.RestaurantFoodCategory
                                        .Where(f => f.RestaurantId == restaurant.Id)
                                        .Select(f => f.FoodCategory).Distinct().ToList();

            ICollection<PlateTime> plateTimes = db.PlateTime
                                        .Where(p => p.RestaurantId == restaurant.Id).ToList();

            var allCategories = db.FoodCategory.ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();
            foreach (var category in allCategories)
            {
                bool IsChecked = false;
                foreach (var c in foodCategories)
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
                if (c.Value == restaurant.PriceCategory.ToString())
                {
                    c.Selected = true;
                    break;
                }
            }

            RestaurantProfileVM profile = new RestaurantProfileVM()
            {
                Id = restaurant.Id,
                UserId = id,
                Name = restaurant.Name,
                Url = restaurant.Url,
                StreetAddress = restaurant.StreetAddress,
                City = restaurant.City,
                PostalCode = restaurant.PostalCode,

                User = user,
                plateTimes = plateTimes,
                foodCategories = foodCategories,

                FoodCategoryCheckboxes = checkBoxListItems,
                PriceCategory = restaurant.PriceCategory,
                PriceCategoryList = priceCategoryDropdownList
            };
            return profile;
        }

        public bool Update(RestaurantProfileVM profile)
        {
            Restaurant restaurant = db.Restaurant
                                    .Where(r => r.UserId == profile.UserId)
                                    .FirstOrDefault();

            if (restaurant == null)
            {
                restaurant = new Restaurant();
                db.Add(restaurant);
                db.SaveChanges();

            }

            restaurant.UserId = profile.UserId;
            restaurant.Name = profile.Name;
            restaurant.PriceCategory = profile.PriceCategory;
            restaurant.Url = profile.Url;
            restaurant.StreetAddress = profile.StreetAddress;
            restaurant.City = profile.City;
            restaurant.PostalCode = profile.PostalCode;
            db.SaveChanges();


            foreach (var checkbox in profile.FoodCategoryCheckboxes)
            {
                if (checkbox.IsChecked)
                {
                    RestaurantFoodCategory entry = new RestaurantFoodCategory()
                    {
                        FoodCategoryId = checkbox.ID,
                        RestaurantId = restaurant.Id
                    };
                    db.Add(entry);
                    db.SaveChanges();
                }
                else
                {
                    ICollection<RestaurantFoodCategory> entries = db.RestaurantFoodCategory
                                        .Where(f => f.RestaurantId == restaurant.Id && f.FoodCategoryId == checkbox.ID)
                                        .Distinct().ToList();
                    foreach (var entry in entries)
                    {
                        db.RestaurantFoodCategory.Remove(entry);
                        db.SaveChanges();
                    }
                }
            }

            PriceCategoryDropdownBuilder helper = new PriceCategoryDropdownBuilder();
            profile.PriceCategory = helper.convertType(profile.PriceCategoryString);
            if (profile.PriceCategory != null)
            {
                restaurant.PriceCategory = profile.PriceCategory;
                db.SaveChanges();
            }

            return true;
        }
    }
}
