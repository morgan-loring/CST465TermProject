using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private IStepsRepository _stepsRepository;
        private IRecipeRepository _recipeRepository;
        private IIngredientRepository _ingredientRepository;
        private Settings _settings;

        public HomeController(IOptions<Settings> settings, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IStepsRepository stepsRepository)
        {
            _ingredientRepository = ingredientRepository;
            _stepsRepository = stepsRepository;
            _recipeRepository = recipeRepository;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            RecipeModel model = _recipeRepository.GetRecipe(_settings.FeaturedRecipeID);
            model.Ingredients = _ingredientRepository.GetIngredients(_settings.FeaturedRecipeID);
            model.Steps = _stepsRepository.GetSteps(_settings.FeaturedRecipeID);
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}