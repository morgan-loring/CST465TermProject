using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IStepsRepository
    {
        void Insert(int key, int order, string step);
        List<string> GetSteps(int id);
    }
}
