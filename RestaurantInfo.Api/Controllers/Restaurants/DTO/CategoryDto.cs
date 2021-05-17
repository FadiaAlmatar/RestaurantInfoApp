using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class CategoryDto
    {
        public string Type { get; set; }
        public string UserId { get; set; }
        public List<MealDto> Meals { get; set; }
    }
}
