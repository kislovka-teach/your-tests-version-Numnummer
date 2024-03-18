using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Services;
using Repository.RepositoryClasses;

namespace Api.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepositiry, UserRepository>();
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<IExcerciseRepository, ExcerciseRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<IReviewService, ReviewService>();
            return services;
        }
    }
}
