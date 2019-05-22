using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlateTimeApp.Models
{
    public partial class PlateTime
    {
        public PlateTime()
        {
            Isopen = true;
            PlateTimeRestaurantGoer = new HashSet<PlateTimeRestaurantGoer>();
        }

        public int Id { get; set; }        
        public int? RestaurantGoerId { get; set; }

        //[Required(ErrorMessage ="A restaurant is necessary for PlateTime to be created.")]
        [DisplayName("Restaurant")]
        public int? RestaurantId { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? Time { get; set; }
        
        [Required(ErrorMessage = "There must be at least one person in a PlateTime.")]
        [Range(1, int.MaxValue, ErrorMessage ="There must be at least one person in a PlateTime.")]
        [DisplayName("Group Size")]
        public int? MaxMembers { get; set; }

        [DisplayName("Status")]
        public bool? Isopen { get; set; }
        public bool? AllCommitted { get; set; }

        public Restaurant Restaurant { get; set; }

        [DisplayName("By")]
        public RestaurantGoer RestaurantGoer { get; set; }
        public ICollection<PlateTimeRestaurantGoer> PlateTimeRestaurantGoer { get; set; }
    }
}
