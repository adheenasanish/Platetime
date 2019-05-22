using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class RestaurantGoerFoodCategory
    {
        public int Id { get; set; }
        public int? RestaurantGoerId { get; set; }
        public int? FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }
        public RestaurantGoer RestaurantGoer { get; set; }
    }
}
