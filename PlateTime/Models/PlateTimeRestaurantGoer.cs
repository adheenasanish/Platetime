using System;
using System.Collections.Generic;

namespace PlateTimeApp.Models
{
    public partial class PlateTimeRestaurantGoer
    {
        public int Id { get; set; }
        public int? PlateTimeId { get; set; }
        public int? RestaurantGoerId { get; set; }

        public PlateTime PlateTime { get; set; }
        public RestaurantGoer RestaurantGoer { get; set; }
    }
}
