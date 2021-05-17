using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public class Order:BaseEntity
    {
        private Order(string note, string place,int restaurantId,string userId)
        {
            Note = note;
            Place = place;
            UserId = userId;
            RestaurantId = restaurantId;
        }
        public static Order Create(string note, string place, int restaurantId,string userId)
        {
            if (String.IsNullOrWhiteSpace(place)) throw new NullReferenceException("place is Null");//validation
            return new Order(note, place,restaurantId,userId);
        }

        public string Note { get; set; }
        public string Place { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
        public List<MealOrder> MealOrders { get; set; } = new List<MealOrder>();
    }
}
