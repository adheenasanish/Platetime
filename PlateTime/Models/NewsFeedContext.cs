using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlateTimeApp.Models
{
    public class NewsFeed
    {
        [Key] // Enables auto-increment.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NewsDate { get; set; }
        public string RestaurantName { get; set; }
        public string CuisineType { get; set; }
        
    }

    public class NewsFeedContext : DbContext
    {

        public NewsFeedContext(DbContextOptions<NewsFeedContext> options) : base(options) { }
        public DbSet<NewsFeed> NewsFeeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsFeed>().HasData(
                new { Id = 1, Title = "Papa John's partners with DoorDash", Description = "The third-party deal will supplement the pizza chian's in-house delivery.", NewsDate = new DateTime(2019, 03, 13), RestaurantName = "Papa John's", CuisineType = "Pizza" },
                new { Id = 2, Title = "Menu Tracker: New items from McDonald's, Fuddruckers, Pie Five", Description = "1000 Degrees Pizza, The Coffee Bean & Tea Leaf, Dos Toros, Fogo de Chão, Grimaldi’s Pizzeria, Growler USA, Jamba Juice, Mimi’s, Num Pang Kitchen, Sizzler and TooJay’s Deli also added new pizzas, seafood dishes and more.", NewsDate = new DateTime(2019, 03, 13), CuisineType = "Fastfood" },
                new { Id = 3, Title = "Chipotle launches new loyalty program", Description = "The chain will promote Chipotle Rewards by giving Venmo payouts to fans", NewsDate = new DateTime(2019, 03, 12), RestaurantName = "Chipotle", CuisineType = "Grill" },
                new { Id = 4, Title = "How Sweetgreen creates its intimacy of scale", Description = "Co-founder Nathaniel Ru outlines DNA of brand’s success", NewsDate = new DateTime(2019, 03, 11), RestaurantName = "Sweetgreen", CuisineType = "Salad" },
                new { Id = 5, Title = "Dunkin Brands names new chief legal officer", Description = "Former hotel executive David Mann tapped for legal, senior vice president roles", NewsDate = new DateTime(2019, 03, 11), RestaurantName = "Dunkin Brands", CuisineType = "Fastfood" },
                new { Id = 6, Title = "Wingstop names new chief growth officer", Description = "Marketing chief Maurice Cooper expands duties with digital role", NewsDate = new DateTime(2019, 03, 13), RestaurantName = "Wingstop", CuisineType = "Grill" },
                new { Id = 7, Title = "KFC names first chief communications officer", Description = "Staci Rawls played a pivotal P.R. role during the brand’s turnaround", NewsDate = new DateTime(2019, 03, 07), RestaurantName = "KFC", CuisineType = "Fastfood" },
                new { Id = 8, Title = "John Schnatter to exit Papa John’s board", Description = "Schnatter will drop legal claims after reaching a settlement with the company", NewsDate = new DateTime(2019, 03, 05), RestaurantName = "Papa John's", CuisineType = "Pizza" }
            );
        }
    }
}
