using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class UpdateMealOrderDto :AddMealOrderDto
    {
        public int Id { get; set; }
    }
}
