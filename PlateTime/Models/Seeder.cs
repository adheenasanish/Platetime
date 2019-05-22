using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Models
{
    public class Seeder
    {
        private PlateTimeContext db;
        public Seeder(PlateTimeContext db)
        {
            this.db = db;
            SeedData();
        }

        public void SeedData()
        {
            // Exit if data exists.
            if (db.FoodCategory.Count() != 0)
            {
                return;
            }

            //Create a collection of Objects to add to the database.
            FoodCategory[] seedFoodCategory = new FoodCategory[]
            {
                new FoodCategory { Name = "Greek" },
                new FoodCategory { Name = "Thai" },
                new FoodCategory { Name = "Mexican" },
                new FoodCategory { Name = "Sushi" },
                new FoodCategory { Name = "Ramen" },
                new FoodCategory { Name = "Poke" },
                new FoodCategory { Name = "Chinese" },
            };

            db.FoodCategory.AddRange(seedFoodCategory);

            db.SaveChanges();
        }

    }
}

