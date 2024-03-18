using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClasses
{
    public class ExcerciseRepository(AppDbContext dbContext, ITrainingRepository trainingRepository) : IExcerciseRepository
    {
        public async Task AddExcerciseAsync(Excercise excercise)
        {
            await dbContext.Excercises.AddAsync(excercise);
        }

        public async Task AddExcerciseToTrainingAsync(Excercise excercise, int trainingId)
        {
            var trainingPlan = new TrainingPlan()
            {
                Excercise = excercise,
                Id = trainingId,
                Training=await trainingRepository.GetTrainingByIdAsync(trainingId)
            };
            await dbContext.TrainingPlans.AddAsync(trainingPlan);
        }

        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
