using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface IReviewRepository : IRepository
    {
        Task AddReviewAsync(User user, Training training, string review, int id);
        Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId);
    }
}
