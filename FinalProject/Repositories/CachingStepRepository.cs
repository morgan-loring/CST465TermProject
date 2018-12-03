using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinalProject.Repositories
{
    public class CachingStepRepository : StepRepository
    {
        IMemoryCache _cache;
        private readonly string _StepPrefix = "StepCache_";

        public CachingStepRepository(IOptions<Settings> settings, IConfiguration config, IMemoryCache cache) : base(settings, config)
        {
            _cache = cache;
        }

        public override void Insert(int key, int order, string ingredient)
        {
            base.Insert(key, order, ingredient);
        }

        public override List<string> GetSteps(int RecipeID)
        {
            List<string> list = (List<string>)_cache.Get(_StepPrefix + "List_" + RecipeID.ToString());
            if (list != null) return list;
            else
            {
                list = base.GetSteps(RecipeID);
                _cache.Set(_StepPrefix + "List_" + RecipeID.ToString(), list);
                return list;
            }
        }

        public override void Delete(int RecipeID)
        {
            base.Delete(RecipeID);
            _cache.Remove(_StepPrefix + "List_" + RecipeID.ToString());
        }
    }
}
