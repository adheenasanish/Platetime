using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            PlateTime = new HashSet<PlateTime>();
            RestaurantFoodCategory = new HashSet<RestaurantFoodCategory>();
            RestaurantGoerRestaurant = new HashSet<RestaurantGoerRestaurant>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int? PriceCategory { get; set; }
        public string Url { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<PlateTime> PlateTime { get; set; }
        public ICollection<RestaurantFoodCategory> RestaurantFoodCategory { get; set; }
        public ICollection<RestaurantGoerRestaurant> RestaurantGoerRestaurant { get; set; }
    }
}
