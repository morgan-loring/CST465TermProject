using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult Index()
        {
            var model = _recipeRepository.GetList();
            return View("SearchResults", model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
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

            model.UserID = User.Claims.ElementAt(0).Value;
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
        [Route("Recipe/DisplayRecipe/{id}")]
        public IActionResult DisplayRecipe(int ID)
        {
            RecipeModel model = null;
            if (ModelState.IsValid)
            {
                model = _recipeRepository.GetRecipe(ID);
                model.Ingredients = _ingredientRepository.GetIngredients(ID);
                model.Steps = _stepsRepository.GetSteps(ID);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRecipe(int id)
        {
            if (ModelState.IsValid)
            {
                _ingredientRepository.Delete(id);
                _stepsRepository.Delete(id);
                _recipeRepository.Delete(id);
            }
            return RedirectToAction("Index", "Recipe");
        }

        [HttpPost]
        public IActionResult Search(string SearchString)
        {
            if (ModelState.IsValid)
            {
                if (SearchString == null)
                {
                    return View("SearchResults", null);
                }
                List<RecipeModel> models = _recipeRepository.Search(SearchString);
                return View("SearchResults", models);
            }
            else
            {
                return View("SearchResults", null);
            }
        }

    }
}