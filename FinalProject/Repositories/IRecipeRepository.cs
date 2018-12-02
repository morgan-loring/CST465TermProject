using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IRecipeRepository
    {
        int Insert(RecipeModel model);
        RecipeModel GetRecipe(int RecipeID);
        List<RecipeModel> Search(string SearchString);
        List<RecipeModel> GetList();
        void Delete(int id);
    }
}
