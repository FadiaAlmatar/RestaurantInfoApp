using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class AddCategoryDto
    {
        public string Type { get; set; }
        public int RestaurantId { get; set; }
    }
}
