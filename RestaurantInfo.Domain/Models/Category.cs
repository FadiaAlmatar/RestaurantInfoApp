using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public  class Category :BaseEntity
    {
        private Category(string type, int restaurantId,string userId)
        {
            Type = type;
           RestaurantId = restaurantId;
            UserId = userId;
            CreationTime = DateTime.Now;
        }
        public static Category Create(string type, int restaurantId, string userId)
        {
            if (String.IsNullOrWhiteSpace(type)) throw new NullReferenceException("type is Null");//validation
            return new Category(type, restaurantId,userId);
        }
        public void Update(string type)
        {
            Type = type;
        }
        public string Type { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();
    }
}
