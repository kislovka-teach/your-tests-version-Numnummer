using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IReviewService
    {
        Task AddReviewAsync(string userLogin, int trainingId, string review);
        Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId);
    }
}
