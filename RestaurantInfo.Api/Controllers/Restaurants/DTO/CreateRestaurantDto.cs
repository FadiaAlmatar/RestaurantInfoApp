using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class CreateRestaurantDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
