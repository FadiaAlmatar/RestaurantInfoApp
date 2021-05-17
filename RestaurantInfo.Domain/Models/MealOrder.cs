using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestaurantInfo.Domain.Models
{
    public class MealOrder:BaseEntity
    {
        private MealOrder(int quantity,int mealId, int orderId)
        {
            Quantity = quantity;
            MealId = mealId;
            OrderId =  orderId;


        }
        public static MealOrder Create(int quantity, int mealId,int orderId)
        {
            
            return new MealOrder(quantity, mealId,orderId);
        }
        public void Update(int quantity)
        {
            Quantity = quantity;
            
        }
        public int Quantity { get; set; }
        public int MealId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal Meal { get; set; }
        public int OrderId { get; set; }
       [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}
