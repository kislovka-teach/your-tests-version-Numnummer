using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReviewService(IUserService userService,
        IReviewRepository reviewRepository, ITrainingService trainingService) : IReviewService
    {
        private static int _reviewIndex = 1;

        public async Task AddReviewAsync(string userLogin, int trainingId, string review)
        {
            var user = await userService.GetUserByLoginAsync(userLogin);
            var training = await trainingService.GetTrainingByIdAsync(trainingId);
            await reviewRepository.AddReviewAsync(user, training, review, _reviewIndex);
            await reviewRepository.SaveChangesAsync();
            _reviewIndex++;
        }

        public async Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId)
        {
            return await reviewRepository.GetAllReviewsForTrainingAsync(trainingId);
        }
    }
}
