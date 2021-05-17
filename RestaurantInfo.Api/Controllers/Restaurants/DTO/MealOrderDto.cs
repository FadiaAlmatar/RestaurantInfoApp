using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class MealOrderDto
    {
        public int Quantity { get; set; }
        public string UserId { get; set; }
    }
}
