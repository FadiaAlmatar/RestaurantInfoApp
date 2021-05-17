using AutoMapper;
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
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantInfo.Api.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Restaurant> _repository;
        
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Meal> _mealRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(IRepository<Restaurant> repository, IRepository<Category> categoryRepo, IRepository<Meal> mealRepo, IMapper mapper, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _categoryRepo = categoryRepo;
            _mealRepo = mealRepo;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
        }

        //CRUD Meal
        [HttpPost(nameof(AddMeal))]
        public async Task AddMeal([FromForm]AddMealDto input) //add meal to category
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string uniqueFileName = GetMovieImageName(input.Image);
            var meal = Meal.Create(input.Name, uniqueFileName, input.Price, input.Calory,input.CategoryId, input.RestaurantId, userId);
            await _mealRepo.AddAsync(meal);
        }

        [HttpDelete(nameof(DeleteMeal))]
        public async Task DeleteMeal(int id) //delete meal
        {
            await _mealRepo.Delete(id);
        }

        [HttpGet(nameof(GetCategoryWithMeals))]
        public async Task<CategoryDto> GetCategoryWithMeals(int id)//get meals
        {
            var category = await _categoryRepo.GetAsync(id, c => c.Meals);
            var categoryDto = _mapper.Map<Category, CategoryDto>(category);
            if (categoryDto.Meals != null)
            {
                categoryDto.Meals.ForEach(item =>
                {
                    var user = _userManager.FindByIdAsync(item.UserId).Result;
                    // item.UserName = user.UserName;
                });
            }

            return categoryDto;
        }

        [HttpPut(nameof(UpdateMeal))]
        public async Task<MealDto> UpdateMeal([FromForm]UpdateMealDto input) //update meal
        {

            var meal = await _mealRepo.GetAsync(input.Id);
            string uniqueFileName = GetMovieImageName(input.Image);
            meal.Update(input.Name, uniqueFileName, input.Price,input.Calory);
            var result = await _mealRepo.Update(meal);
            return _mapper.Map<Meal, MealDto>(result);
        }

        private string GetMovieImageName(IFormFile image)
        {
            string uniqueFileName = null;
            if (image != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
