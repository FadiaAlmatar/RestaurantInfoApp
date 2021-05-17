using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class MealComponentDto
    {
        
        public string Name { get; set; }
        public string Image { get; set; }
        public float Weight { get; set; }
    }
}
