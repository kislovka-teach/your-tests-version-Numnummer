using Domain.Abstractions;
using Domain.Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IRepository _repository;
        public TrainingService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddExcerciseToTrainingAsync(Excercise excercise, int id)
        {
            await _repository.AddExcerciseAsync(excercise);
            await _repository.AddExcerciseToTrainingAsync(excercise, id);
            await _repository.SaveChangesAsync();
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
            return await _repository.GetTrainingByIdAsync(id);
        }
    }
}
