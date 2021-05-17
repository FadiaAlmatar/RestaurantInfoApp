using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public class Meal:BaseEntity
    {
        private Meal(string name, string image, float price, float calory, int categoryId,int restaurantId, string userId)
        {
            Name = name;
            Image = image;
            Price = price;
            Calory = calory;
           CategoryId = categoryId;
            RestaurantId = restaurantId;
            UserId = userId;
        }
        public static Meal Create(string name, string image, float price, float calory,int categoryId,int restaurantId,string userId)
        {
          
            return new Meal(name, image,price,calory,categoryId,restaurantId, userId);
        }
        public void Update(string name, string image, float price, float calory)
        {
            Name = name;
            Image = image;
            Price = price;
            Calory = calory;
            
        }
        public string Name { get; set; }
        public  string Image { get; set; }
        public float Price { get; set; }
        public float Calory { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public List<ComponentMeal> ComponentMeals { get; set; } = new List<ComponentMeal>();
        public List<MealOrder> MealOrders { get; set; } = new List<MealOrder>();

    }
}
