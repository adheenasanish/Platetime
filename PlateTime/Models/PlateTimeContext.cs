using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlateTimeApp.ViewModel;

namespace PlateTimeApp.Models
{
    public partial class PlateTimeContext : DbContext
    {
        public PlateTimeContext()
        {
        }

        public PlateTimeContext(DbContextOptions<PlateTimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<FoodCategory> FoodCategory { get; set; }
        public virtual DbSet<PlateTime> PlateTime { get; set; }
        public virtual DbSet<PlateTimeRestaurantGoer> PlateTimeRestaurantGoer { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantFoodCategory> RestaurantFoodCategory { get; set; }
        public virtual DbSet<RestaurantGoer> RestaurantGoer { get; set; }
        public virtual DbSet<RestaurantGoerFoodCategory> RestaurantGoerFoodCategory { get; set; }
        public virtual DbSet<RestaurantGoerRestaurant> RestaurantGoerRestaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("food_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlateTime>(entity =>
            {
                entity.ToTable("plate_time");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllCommitted).HasColumnName("all_committed");

                entity.Property(e => e.Isopen).HasColumnName("isopen");

                entity.Property(e => e.MaxMembers).HasColumnName("max_members");

                entity.Property(e => e.RestaurantGoerId).HasColumnName("restaurant_goer_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.RestaurantGoer)
                    .WithMany(p => p.PlateTime)
                    .HasForeignKey(d => d.RestaurantGoerId)
                    .HasConstraintName("FK__plate_tim__resta__72C60C4A");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.PlateTime)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__plate_tim__resta__73BA3083");
            });

            modelBuilder.Entity<PlateTimeRestaurantGoer>(entity =>
            {
                entity.ToTable("plate_time_restaurant_goer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlateTimeId).HasColumnName("plate_time_id");

                entity.Property(e => e.RestaurantGoerId).HasColumnName("restaurant_goer_id");

                entity.HasOne(d => d.PlateTime)
                    .WithMany(p => p.PlateTimeRestaurantGoer)
                    .HasForeignKey(d => d.PlateTimeId)
                    .HasConstraintName("FK__plate_tim__plate__03F0984C");

                entity.HasOne(d => d.RestaurantGoer)
                    .WithMany(p => p.PlateTimeRestaurantGoer)
                    .HasForeignKey(d => d.RestaurantGoerId)
                    .HasConstraintName("FK__plate_tim__resta__04E4BC85");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCategory).HasColumnName("price_category");

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("street_address")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Restaurant)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__restauran__user___6D0D32F4");
            });

            modelBuilder.Entity<RestaurantFoodCategory>(entity =>
            {
                entity.ToTable("restaurant_food_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FoodCategoryId).HasColumnName("food_category_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.RestaurantFoodCategory)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK__restauran__food___7D439ABD");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantFoodCategory)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__restauran__resta__7C4F7684");
            });

            modelBuilder.Entity<RestaurantGoer>(entity =>
            {
                entity.ToTable("restaurant_goer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCategory).HasColumnName("price_category");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RestaurantGoer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__restauran__user___6FE99F9F");
            });

            modelBuilder.Entity<RestaurantGoerFoodCategory>(entity =>
            {
                entity.ToTable("restaurant_goer_food_category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FoodCategoryId).HasColumnName("food_category_id");

                entity.Property(e => e.RestaurantGoerId).HasColumnName("restaurant_goer_id");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.RestaurantGoerFoodCategory)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK__restauran__food___797309D9");

                entity.HasOne(d => d.RestaurantGoer)
                    .WithMany(p => p.RestaurantGoerFoodCategory)
                    .HasForeignKey(d => d.RestaurantGoerId)
                    .HasConstraintName("FK__restauran__resta__787EE5A0");
            });

            modelBuilder.Entity<RestaurantGoerRestaurant>(entity =>
            {
                entity.ToTable("restaurant_goer_restaurant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RestaurantGoerId).HasColumnName("restaurant_goer_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.HasOne(d => d.RestaurantGoer)
                    .WithMany(p => p.RestaurantGoerRestaurant)
                    .HasForeignKey(d => d.RestaurantGoerId)
                    .HasConstraintName("FK__restauran__resta__00200768");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantGoerRestaurant)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__restauran__resta__01142BA1");
            });
        }

        //public DbSet<PlateTimeApp.ViewModel.RestaurantProfileVM> RestaurantProfileVM { get; set; }
    }
}
