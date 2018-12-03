using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinalProject.Repositories
{
    public class CachingIngredientRepository : IngredientRepository
    {
        private IMemoryCache _cache;
        private readonly string _IngredientPrefix = "IngredientCache_";
        public CachingIngredientRepository(IOptions<Settings> settings, IConfiguration config, IMemoryCache cache) : base(settings, config)
        {
            _cache = cache;
        }

        public override void Insert(int key, int order, string ingredient)
        {
            base.Insert(key, order, ingredient);
        }

        public override List<string> GetIngredients(int id)
        {
            List<string> list = (List<string>)_cache.Get(_IngredientPrefix + "List_" + id.ToString());
            if (list != null) return list;
            else
            {
                list = base.GetIngredients(id);
                _cache.Set(_IngredientPrefix + "List_" + id.ToString(), list);
                return list;
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            _cache.Remove(_IngredientPrefix + "List_" + id.ToString());
        }
    }
}
