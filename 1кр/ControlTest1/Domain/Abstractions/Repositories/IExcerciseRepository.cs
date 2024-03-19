using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IExcerciseRepository : IRepository
    {
        Task AddExcerciseAsync(Excercise excercise);
        Task AddExcerciseToTrainingAsync(Excercise excercise, int trainingId);
    }
}
