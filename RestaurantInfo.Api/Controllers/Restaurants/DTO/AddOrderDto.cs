using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class AddOrderDto
    {
        public string Place { get; set; }
        public string Note { get; set; }
        public int RestaurantId { get; set; }
    }
}
