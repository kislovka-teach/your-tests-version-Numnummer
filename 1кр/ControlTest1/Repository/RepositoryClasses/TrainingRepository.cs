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
    public class TrainingRepository(AppDbContext dbContext) : ITrainingRepository
    {
        public async Task<Training?> GetTrainingByIdAsync(int id)
        {
            return await dbContext.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
