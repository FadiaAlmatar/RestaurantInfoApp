using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants.DTO
{
    public class RestaurantDto
    {
        public RestaurantDto(string name, string address, int id)
        {
            Name = name;
            Address = address;
            Id = id;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Id{ get; set; }
        public List<OrderDto> Orders { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
