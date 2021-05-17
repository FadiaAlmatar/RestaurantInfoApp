using AutoMapper;
using RestaurantInfo.Api.Controllers.Restaurants.DTO;
using RestaurantInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants
{
    public class RestaurantsAutoMapperProfile : Profile
    {
        public RestaurantsAutoMapperProfile()
        {
            CreateMap<CreateRestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Meal, MealDto>();
            CreateMap<ComponentMeal, MealComponentDto>();
            CreateMap<MealOrder, MealOrderDto>();
        }
    }
}
