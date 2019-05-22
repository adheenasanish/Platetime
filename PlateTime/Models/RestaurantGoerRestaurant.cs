using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class RestaurantGoerRestaurant
    {
        public int Id { get; set; }
        public int? RestaurantGoerId { get; set; }
        public int? RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        public RestaurantGoer RestaurantGoer { get; set; }
    }
}
