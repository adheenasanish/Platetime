using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Models
{
    public class PriceCategoryDropdownBuilder
    {
        public List<SelectListItem> priceCategories;

        public PriceCategoryDropdownBuilder()
        {
            priceCategories = new List<SelectListItem>();

            priceCategories.Add(new SelectListItem() { Value = "1", Text = "$" });
            priceCategories.Add(new SelectListItem() { Value = "2", Text = "$$" });
            priceCategories.Add(new SelectListItem() { Value = "3", Text = "$$$" });
            priceCategories.Add(new SelectListItem() { Value = "4", Text = "$$$$" });
            priceCategories.Add(new SelectListItem() { Value = "5", Text = "$$$$$" });
        }

        public int? convertType(String categoryString)
        {
            switch (categoryString)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                default:
                    return null;
            }
        }


    }
}
