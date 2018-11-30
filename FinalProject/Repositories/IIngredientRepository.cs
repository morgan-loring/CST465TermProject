using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IIngredientRepository
    {
        void Insert(int key, int order, string ingredient);
        List<string> GetIngredients(int id);
    }
}
