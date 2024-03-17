using Microsoft.EntityFrameworkCore;
using Repository.Configurations;
using Repository.Models;

namespace Repository
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Excercise> Excercises => Set<Excercise>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<TrainingPlan> TrainingPlans => Set<TrainingPlan>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Review> Reviews => Set<Review>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Training>(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration<Excercise>(new ExerciseConfiguration());
            modelBuilder.Entity<Review>().HasKey(x => x.Id);
            modelBuilder.Entity<TrainingPlan>().HasKey(x => x.Id);
        }
    }
}
