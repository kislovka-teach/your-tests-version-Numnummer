using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Repository.Models;

namespace Domain.Services
{
    public class TrainingService(IExcerciseRepository excerciseRepository,
        ITrainingRepository trainingRepository) : ITrainingService
    {

        public async Task AddExcerciseToTrainingAsync(Excercise excercise, int id)
        {
            await excerciseRepository.AddExcerciseAsync(excercise);
            await excerciseRepository.AddExcerciseToTrainingAsync(excercise, id);
            await excerciseRepository.SaveChangesAsync();
        }

        public Excercise GetRandomExcercise()
        {
            var random = new Random();
            var bytes = new byte[32];
            random.NextBytes(bytes);
            return new Excercise()
            {
                ApproachesCount=random.Next(10),
                Description=bytes[0].ToString(),
                Duration=random.Next(40),
                Id=random.Next(20),
                Name=bytes[1].ToString(),
                RestDuration=random.Next(40)
            };
        }

        public async Task<Training?> GetTrainingByIdAsync(int id)
        {
            return await trainingRepository.GetTrainingByIdAsync(id);
        }
    }
}
