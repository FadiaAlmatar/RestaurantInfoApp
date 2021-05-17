using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class OrderDto
    {
        public string Place { get; set; }
        public string Note { get; set; }
        public string UserId { get; set; }
        public List<MealOrderDto> MealOrders { get; set; }
    }
}
