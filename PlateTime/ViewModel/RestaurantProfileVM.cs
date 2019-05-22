using Microsoft.AspNetCore.Mvc.Rendering;
using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.ViewModel
{
    public class RestaurantProfileVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<PlateTime> plateTimes { get; set; }
        public ICollection<RestaurantFoodCategory> restaurantFoodCategory { get; set; }
        public ICollection<RestaurantGoerRestaurant> restaurantGoerRestaurant { get; set; }
        public ICollection<FoodCategory> foodCategories { get; set; }

        public List<CheckBoxListItem> FoodCategoryCheckboxes { get; set; }

        public int? PriceCategory { get; set; }
        public string PriceCategoryString { get; set; }
        public List<SelectListItem> PriceCategoryList { get; set; }

        public RestaurantProfileVM()
        {
            FoodCategoryCheckboxes = new List<CheckBoxListItem>();
        }
    }
}
