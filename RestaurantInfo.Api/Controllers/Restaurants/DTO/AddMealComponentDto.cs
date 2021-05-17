using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class AddMealComponentDto 
    {
        
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public float Weight { get; set; }
        public int MealId { get; set; }
    }
}
