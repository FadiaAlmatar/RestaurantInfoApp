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

namespace RestaurantInfo.Api.Controllers.Meals
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IRepository<Restaurant> _repository;

        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Meal> _mealRepo;
        private readonly IRepository<ComponentMeal> _mealComponentRepo;
        private readonly IRepository<MealOrder> _mealOrderRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealsController(IRepository<Restaurant> repository, IRepository<MealOrder> mealOrderRepo, IRepository<ComponentMeal> mealComponentRepo, IRepository<Category> categoryRepo, IRepository<Meal> mealRepo, IMapper mapper, IWebHostEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _categoryRepo = categoryRepo;
            _mealRepo = mealRepo;
            _mealComponentRepo = mealComponentRepo;
            _mealOrderRepo = mealOrderRepo;
           _mapper = mapper;
            _env = env;
            _userManager = userManager;
        }

        //CRUD Component
        [HttpPost(nameof(AddComponent))]
        public async Task AddComponent([FromForm]AddMealComponentDto input) //add component to meal
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string uniqueFileName = GetMovieImageName(input.Image);
            var componentMeal = ComponentMeal.Create(input.Weight,input.Name, uniqueFileName,input.MealId);
            await _mealComponentRepo.AddAsync(componentMeal);
        }

        [HttpDelete(nameof(DeleteComponent))]
        public async Task DeleteComponent(int id) //delete component
        {
            await _mealComponentRepo.Delete(id);
        }

        [HttpGet(nameof(GetComponentsInMeal))]
        public async Task<MealDto> GetComponentsInMeal(int id)//get components in meal
        {
            var meal = await _mealRepo.GetAsync(id, m => m.ComponentMeals);
            var mealDto = _mapper.Map<Meal, MealDto>(meal);
            //if (mealDto.ComponentMeals != null)
            //{
            //    mealDto.ComponentMeals.ForEach(item =>
            //    {
            //        var user = _userManager.FindByIdAsync(item.UserId).Result;
            //        // item.UserName = user.UserName;
            //    });
            //}

            return mealDto;
        }

        [HttpPut(nameof(UpdateComponent))]
        public async Task<MealComponentDto> UpdateComponent([FromForm] UpdateMealComponentDto input) //update component
        {

            var component = await _mealComponentRepo.GetAsync(input.Id);
            string uniqueFileName = GetMovieImageName(input.Image);
            component.Update(input.Weight,input.Name, uniqueFileName);
            var result = await _mealComponentRepo.Update(component);
            return _mapper.Map<ComponentMeal, MealComponentDto>(result);
        }


        //CRUD MealOrder
        [HttpPost(nameof(AddMealOrder))]
        public async Task AddMealOrder( AddMealOrderDto input) //add meal order
        {
            var mealOrder = MealOrder.Create(input.Quantity,input.MealId,input.OrderId);
            await _mealOrderRepo.AddAsync(mealOrder);
        }
        [HttpPut(nameof(UpdateMealOrder))]
        public async Task<MealOrderDto> UpdateMealOrder( UpdateMealOrderDto input) //update meal order
        {

            var mealOrder = await _mealOrderRepo.GetAsync(input.Id);
            
            mealOrder.Update(input.Quantity);
            var result = await _mealOrderRepo.Update(mealOrder);
            return _mapper.Map<MealOrder, MealOrderDto>(result);
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
