using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public class ComponentMeal:BaseEntity
    {
        private ComponentMeal(float weight, string name, string image,int mealId)
        {
            Weight = weight;
            MealId = mealId;
            Name = name;
            Image = image;
        }
        public static ComponentMeal Create(float weight,string name,string image, int mealId)
        {
            
            return new ComponentMeal(weight, name, image,mealId);
        }
        public void Update(float weight, string name, string image)
        {
            Weight = weight;
            
            Name = name;
            Image = image;
        }
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
       //public int ComponentId { get; set; }
       // [ForeignKey(nameof(ComponentId))]
       // public Component Component{ get; set; }
        public float Weight { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
