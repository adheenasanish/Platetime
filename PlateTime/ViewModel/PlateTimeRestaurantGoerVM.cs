using PlateTimeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.ViewModel
{
    public class PlateTimeRestaurantGoerVM
    {
        public List<RestaurantGoer> RestaurantGoers { get; set; }
        public PlateTime PlateTimes { get; set; }
        public bool Committed { get; set; }
    }
}
