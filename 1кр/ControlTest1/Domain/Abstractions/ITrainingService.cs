using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ITrainingService
    {
        Task<Training> GetTrainingByIdAsync(int id);
        Excercise GetRandomExcercise();
        Task AddExcerciseToTrainingAsync(Excercise excercise, int id);
    }
}
