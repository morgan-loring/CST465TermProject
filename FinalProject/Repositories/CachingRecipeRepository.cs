using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinalProject.Repositories
{
    public class CachingRecipeRepository : RecipeRepository
    {
        private IMemoryCache _cache;
        private readonly string _CachePrefix = "RecipeCache_";

        public CachingRecipeRepository(IOptions<Settings> settings, IConfiguration config, IMemoryCache cache) : base(settings, config)
        {
            _cache = cache;
        }

        public override int Insert(RecipeModel model)
        {
            int newId = base.Insert(model);
            model.ID = newId;
            _cache.Set(_CachePrefix + "Recipe_" + newId.ToString(), model);
            _cache.Remove(_CachePrefix + "List");
            return newId;
        }

        public override RecipeModel GetRecipe(int RecipeID)
        {
            RecipeModel recipe = (RecipeModel)_cache.Get(_CachePrefix + "Recipe_" + RecipeID.ToString());
            if (recipe != null) return recipe;
            else
            {
                recipe = base.GetRecipe(RecipeID);
                _cache.Set(_CachePrefix + "Recipe_" + RecipeID.ToString(), recipe);
                return recipe;
            }
        }

        public override List<RecipeModel> Search(string SearchString)
        {
            return base.Search(SearchString);
        }

        public override List<RecipeModel> GetList()
        {
            List<RecipeModel> recipes = (List<RecipeModel>)_cache.Get(_CachePrefix + "List");
            if (recipes != null) return recipes;
            else
            {
                recipes = base.GetList();
                _cache.Set(_CachePrefix + "List", recipes);
                return recipes;
            }
        }

        public override void Delete(int RecipeID)
        {
            base.Delete(RecipeID);
            _cache.Remove(_CachePrefix + "List");
            _cache.Remove(_CachePrefix + "Recipe_" + RecipeID.ToString());
        }
    }
}
