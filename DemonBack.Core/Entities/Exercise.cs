using DemonBack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public MuscleGroup MuscleGroup { get; set; } = MuscleGroup.Unknown;

        public string? Description { get; set; }

        public string? AnimeIconUrl { get; set; }

        // Navigation
        public ICollection<PathExercise> PathExercises { get; set; } = new List<PathExercise>();
        public ICollection<UserPlanDayExercise> UserPlanDayExercises { get; set; } = new List<UserPlanDayExercise>();
        public ICollection<WorkoutSessionExercise> WorkoutSessionExercises { get; set; } = new List<WorkoutSessionExercise>();
    }
}
