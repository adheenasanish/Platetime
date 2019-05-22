using Microsoft.AspNetCore.Mvc.Rendering;
using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.ViewModel
{
    public class UserProfileVM
    {
        public AspNetUsers aspNetUsers { get; set; }
        public RestaurantGoer restaurantGoer { get; set; }
        public ICollection<Restaurant> restaurantList { get; set; }
        public ICollection<FoodCategory> foodCategoryList { get; set; }
        public ICollection<RestaurantGoerFoodCategory> restaurantGoerFoodCategory { get; set; }
        public ICollection<RestaurantGoerRestaurant> restaurantGoerRestaurant { get; set; }
        public string Name { get; set; }

        [DisplayName("Price Range")]
        public int price_category { get; set; }


        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }

        [DisplayName("Food Category Name")]
        public string foodCategoryName { get; set; }

        public List<CheckBoxListItem> FoodCategoryCheckboxes { get; set; }
        public ICollection<FoodCategory> foodCategories { get; set; }

        public int? PriceCategory { get; set; }
        public string PriceCategoryString { get; set; }
        public List<SelectListItem> PriceCategoryList { get; set; }

        public UserProfileVM()
        {
            FoodCategoryCheckboxes = new List<CheckBoxListItem>();
        }

    }
}
