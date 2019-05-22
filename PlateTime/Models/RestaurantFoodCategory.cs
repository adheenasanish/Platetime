using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class RestaurantFoodCategory
    {
        public int Id { get; set; }
        public int? RestaurantId { get; set; }
        public int? FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
