using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class AddMealDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public float Price { get; set; }
        public float Calory { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
    }
}
