using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task AddExcerciseAsync(Excercise excercise)
        {
            await _dbContext.Excercises.AddAsync(excercise);
        }

        public async Task AddExcerciseToTrainingAsync(Excercise excercise, int trainingId)
        {
            var trainingPlan = new TrainingPlan()
            {
                Excercise = excercise,
                Id = trainingId,
                Training=await GetTrainingByIdAsync(trainingId)
            };
            await _dbContext.TrainingPlans.AddAsync(trainingPlan);
        }

        public async Task AddReviewAsync(User user, Training training, string review, int id)
        {
            await Console.Out.WriteLineAsync(review);
            await _dbContext.Reviews.AddAsync(new Review()
            {
                Id = id,
                User = user,
                Training = training,
                Text = review
            });
        }

        public async Task<User?> FindUserAsync(string login, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Login == login && x.Password==password);
        }

        public async Task<User?> FindUserByLoginAsync(string login)
        {
            return await _dbContext.Users.FindAsync(login);
        }

        public async Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId)
        {
            return await _dbContext.Reviews.Where(re => re.Training.Id== trainingId).ToArrayAsync();
        }

        public async Task<Training?> GetTrainingByIdAsync(int id)
        {
            return await _dbContext.Trainings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
