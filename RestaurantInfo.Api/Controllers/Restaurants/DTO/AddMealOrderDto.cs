using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class AddMealOrderDto
    {
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public int OrderId { get; set; }
    }
}
