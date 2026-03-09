using DemonBack.Core.Entities; // Add this using directive
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBodyLog> BodyLogs { get; set; } // Nhớ public class này bên Core nhé
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<AnimePath> AnimePaths { get; set; }
        public DbSet<PathExercise> PathExercises { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<UserPlanDay> UserPlanDays { get; set; }
        public DbSet<UserPlanDayExercise> UserPlanDayExercises { get; set; }
        public DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutSessionExercise> WorkoutSessionExercises { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
