using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class MealDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float Calory { get; set; }
        public string UserId { get; set; }
        public List<MealComponentDto> ComponentMeals { get; set; }
    }
}
