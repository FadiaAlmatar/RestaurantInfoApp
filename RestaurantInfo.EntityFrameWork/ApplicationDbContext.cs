using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantInfo.EntityFrameWork
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        //public DbSet<Component> Components { get; set; }
        public DbSet<ComponentMeal> ComponentMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealOrder> MealOrders { get; set; }
        public DbSet<Order>Orders{ get; set; }
        public DbSet<Restaurant> Restaurants{ get; set; }

    }
}
