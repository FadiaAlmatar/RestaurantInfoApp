using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantInfo.Api.Controllers.Restaurants.DTO;
using RestaurantInfo.Domain.Models;
using RestaurantInfo.EntityFrameWork;
using RestaurantInfo.EntityFrameWork.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Restaurants
{
    
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRepository<Restaurant> _repository;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Meal> _mealRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public RestaurantsController(IRepository<Restaurant> repository, IRepository<Meal> mealRepo, IRepository<Order> orderRepo, IRepository<Category> categoryRepo, IMapper mapper, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _orderRepo = orderRepo;
            _categoryRepo = categoryRepo;
            _mealRepo = mealRepo;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
        }

        //CRUD Restaurant
        [HttpPost(nameof(AddRestaurant))]
        public async Task<RestaurantDto> AddRestaurant( CreateRestaurantDto input)//add restaurant
        {
            
            var restaurant = Restaurant.Create(input.Name, input.Address);
            var result = await _repository.AddAsync(restaurant);
            return _mapper.Map<Restaurant, RestaurantDto>(result);
        }

        [HttpGet(nameof(GetAllRestaurants))]
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()//get all restaurants
        {
            var restaurants = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Restaurant>, IEnumerable<RestaurantDto>>(restaurants);
        }

        [HttpDelete(nameof(DeleteRestaurant))]
        public async Task DeleteRestaurant(int id)//delete restaurant
        {
            await _repository.Delete(id);

        }

        [HttpPut(nameof(UpdateRestaurantInfo))]
        public async Task<RestaurantDto> UpdateRestaurantInfo(UpdateRestaurantDto input) //update restaurant infomation
        {

            var restaurant = await _repository.GetAsync(input.Id);
            restaurant.Update(input.Name, input.Address);
            var result = await _repository.Update(restaurant);
            return _mapper.Map<Restaurant, RestaurantDto>(result);
        }

        //CRUD Order
        [HttpPost(nameof(AddOrderToRestaurant))]
        public async Task AddOrderToRestaurant(AddOrderDto input)//add order to specific restaurant
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var order = Order.Create(input.Note, input.Place,input.RestaurantId,userId);
            await _orderRepo.AddAsync(order);
        }
        [HttpDelete(nameof(DeleteOrder))]
        public async Task DeleteOrder(int id)//delete order
        {
            await _orderRepo.Delete(id);
        }
        [HttpGet(nameof(GetRestaurantWithOrders))]
        public async Task<RestaurantDto> GetRestaurantWithOrders(int id)//get orders
        {
            var restaurant = await _repository.GetAsync(id, r => r.Orders);
            var restaurantDto = _mapper.Map<Restaurant, RestaurantDto>(restaurant);
            if (restaurantDto.Orders != null)
            {
                restaurantDto.Orders.ForEach(item =>
                {
                    var user = _userManager.FindByIdAsync(item.UserId).Result;
                   // item.UserName = user.UserName;
                });
            }

            return restaurantDto;
        }

        [HttpGet(nameof(GetMealOrdersRelatedToOrder))]
        public async Task<OrderDto> GetMealOrdersRelatedToOrder(int id)//get mealOrders
        {
            var order = await _orderRepo.GetAsync(id, o => o.MealOrders);
            var orderDto = _mapper.Map<Order, OrderDto>(order);
            if (orderDto.MealOrders != null)
            {
                orderDto.MealOrders.ForEach(item =>
                {
                    var user = _userManager.FindByIdAsync(item.UserId).Result;
                    // item.UserName = user.UserName;
                });
            }

            return orderDto;
        }

        //CRUD category
        [HttpPost(nameof(AddCategory))]
        public async Task AddCategory(AddCategoryDto input)//add category to restaurant
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var category = Category.Create(input.Type,input.RestaurantId ,userId);
            await _categoryRepo.AddAsync(category);
        }
        [HttpDelete(nameof(DeleteCategory))]
        public async Task DeleteCategory(int id)//delete category
        {
            await _categoryRepo.Delete(id);
        }
        [HttpGet(nameof(GetRestaurantWithCategories))]
        public async Task<RestaurantDto> GetRestaurantWithCategories(int id)//get categories
        {
            var restaurant = await _repository.GetAsync(id, r => r.Categories);
            var restaurantDto = _mapper.Map<Restaurant, RestaurantDto>(restaurant);
            if (restaurantDto.Categories != null)
            {
                restaurantDto.Categories.ForEach(item =>
                {
                    var user = _userManager.FindByIdAsync(item.UserId).Result;
                    // item.UserName = user.UserName;
                });
            }

            return restaurantDto;
        }

        [HttpPut(nameof(UpdateCategory))]
        public async Task<CategoryDto> UpdateCategory(UpdateCategoryDto input) //update category
        {

            var category = await _categoryRepo.GetAsync(input.Id);
            category.Update(input.Type);
            var result = await _categoryRepo.Update(category);
            return _mapper.Map<Category, CategoryDto>(result);
        }



    }
}
