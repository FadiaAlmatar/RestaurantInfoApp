using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class UpdateMealComponentDto :AddMealComponentDto
    {
        public int Id { get; set; }
    }
}
