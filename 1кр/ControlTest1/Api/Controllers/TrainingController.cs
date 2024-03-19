using Domain.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly IReviewService _reviewService;

        public TrainingController(ITrainingService trainingService, IReviewService reviewService)
        {
            _trainingService = trainingService;
            _reviewService=reviewService;
        }

        [HttpGet("training/{id}")]
        [Authorize(Roles = "user, couch")]
        public async Task<IActionResult> GetTrainingByIdAsync(int id)
        {
            var training = await _trainingService.GetTrainingByIdAsync(id);
            return Ok(training);
        }

        [HttpPost("training/{id}/addExcercise")]
        [Authorize(Roles = "couch")]
        public async Task<IActionResult> AddExcerciseAsync([FromRoute] int id)
        {
            var excercise = _trainingService.GetRandomExcercise();
            await _trainingService.AddExcerciseToTrainingAsync(excercise, id);
            return Ok();
        }

        [HttpPost("training/{id}/leaveReview/{review}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> LeaveReviewAsync(int id, [FromForm] string review)
        {
            var login = HttpContext.User.FindFirst(ClaimTypes.Name);
            await Console.Out.WriteLineAsync("re"+review);
            await _reviewService.AddReviewAsync(login.Value, id, review);
            return Ok();
        }

        [HttpGet("training/{id}/review")]
        [Authorize(Roles = "user,couch")]
        public async Task<IActionResult> GetAllReviewsAsync(int id)
        {
            var reviews = await _reviewService.GetAllReviewsForTrainingAsync(id);
            return Ok(reviews);
        }
    }
}
