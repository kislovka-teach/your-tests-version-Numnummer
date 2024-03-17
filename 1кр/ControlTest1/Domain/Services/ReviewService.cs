using Domain.Abstractions;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReviewService(IUserService userService,
        IRepository repository, ITrainingService trainingService) : IReviewService
    {
        private static int _reviewIndex = 1;

        public async Task AddReviewAsync(string userLogin, int trainingId, string review)
        {
            var user = await userService.GetUserByLoginAsync(userLogin);
            var training = await trainingService.GetTrainingByIdAsync(trainingId);
            await repository.AddReviewAsync(user, training, review, _reviewIndex);
            await repository.SaveChangesAsync();
            _reviewIndex++;
        }

        public async Task<Review[]> GetAllReviewsForTrainingAsync(int trainingId)
        {
            return await repository.GetAllReviewsForTrainingAsync(trainingId);
        }
    }
}
