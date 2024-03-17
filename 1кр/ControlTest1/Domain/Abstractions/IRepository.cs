using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IRepository
    {
        Task<User?> FindUserAsync(string login, string password);
        Task<User?> FindUserByLoginAsync(string login);
        Task<Training?> GetTrainingByIdAsync(int id);
        Task AddExcerciseAsync(Excercise excercise);
        Task AddExcerciseToTrainingAsync(Excercise excercise, int trainingId);
        Task AddReviewAsync(User user, Training training, string review, int id);
        Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId);
        Task SaveChangesAsync();
    }
}
