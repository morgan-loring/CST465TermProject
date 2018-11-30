using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class RecipeController : Controller
    {
        IRecipeRepository _recipeRepository;
        IIngredientRepository _ingredientRepository;
        IStepsRepository _stepsRepository;

        public RecipeController(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IStepsRepository stepsRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _stepsRepository = stepsRepository;
        }

        public IActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(RecipeModel model)
        {
            for(int ii = 0; ii < model.Ingredients.Count; ii++)
            {
                if (model.Ingredients[ii] == null)
                {
                    model.Ingredients.RemoveAt(ii);
                    ii--;
                }
            }
            for (int ii = 0; ii < model.Steps.Count; ii++)
            {
                if (model.Steps[ii] == null)
                {
                    model.Steps.RemoveAt(ii);
                    ii--;
                }
            }

            int newKey = _recipeRepository.Insert(model);
            for (int ii = 0; ii < model.Ingredients.Count; ii++)
            {
                _ingredientRepository.Insert(newKey, ii + 1, model.Ingredients[ii]);
            }

            for (int ii = 0; ii < model.Steps.Count; ii++)
            {
                _stepsRepository.Insert(newKey, ii + 1, model.Steps[ii]);
            }
            
            return RedirectToAction("DisplayRecipe", new { ID = newKey});
        }

        [HttpGet]
        public IActionResult DisplayRecipe(int ID)
        {
            RecipeModel model = _recipeRepository.GetRecipe(ID);
            model.Ingredients = _ingredientRepository.GetIngredients(ID);
            model.Steps = _stepsRepository.GetSteps(ID);

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string SearchString)
        {
            if (SearchString == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<RecipeModel> models = _recipeRepository.Search(SearchString);
            return View("SearchResults", models);
        }

        //public IActionResult SearchResults(List<RecipeModel> models)
        //{
        //    return View(models);
        //}
    }
}