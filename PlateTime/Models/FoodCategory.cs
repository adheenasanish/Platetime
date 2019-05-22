using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class FoodCategory
    {
        public FoodCategory()
        {
            RestaurantFoodCategory = new HashSet<RestaurantFoodCategory>();
            RestaurantGoerFoodCategory = new HashSet<RestaurantGoerFoodCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RestaurantFoodCategory> RestaurantFoodCategory { get; set; }
        public ICollection<RestaurantGoerFoodCategory> RestaurantGoerFoodCategory { get; set; }
    }
}
