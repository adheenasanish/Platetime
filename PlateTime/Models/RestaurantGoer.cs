using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class RestaurantGoer
    {
        public RestaurantGoer()
        {
            PlateTime = new HashSet<PlateTime>();
            PlateTimeRestaurantGoer = new HashSet<PlateTimeRestaurantGoer>();
            RestaurantGoerFoodCategory = new HashSet<RestaurantGoerFoodCategory>();
            RestaurantGoerRestaurant = new HashSet<RestaurantGoerRestaurant>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int? PriceCategory { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<PlateTime> PlateTime { get; set; }
        public ICollection<PlateTimeRestaurantGoer> PlateTimeRestaurantGoer { get; set; }
        public ICollection<RestaurantGoerFoodCategory> RestaurantGoerFoodCategory { get; set; }
        public ICollection<RestaurantGoerRestaurant> RestaurantGoerRestaurant { get; set; }
    }
}
