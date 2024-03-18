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
    public class ReviewRepository(AppDbContext dbContext) : IReviewRepository
    {
        public async Task AddReviewAsync(User user, Training training, string review, int id)
        {
            await Console.Out.WriteLineAsync(review);
            await dbContext.Reviews.AddAsync(new Review()
            {
                Id = id,
                User = user,
                Training = training,
                Text = review
            });
        }

        public async Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId)
        {
            return await dbContext.Reviews.Where(re => re.Training.Id== trainingId).ToArrayAsync();
        }

        public async Task SaveChangesAsync() => await dbContext.SaveChangesAsync();
    }
}
