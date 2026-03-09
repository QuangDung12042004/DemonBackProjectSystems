using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class WorkoutSet
    {
        public Guid Id { get; set; }

        public Guid SessionExerciseId { get; set; }
        public WorkoutSessionExercise? SessionExercise { get; set; }

        public int SetNumber { get; set; }

        public decimal WeightKg { get; set; }

        public int Reps { get; set; }

        public decimal? Rpe { get; set; }

        public bool IsWarmup { get; set; }
        public bool IsPr { get; set; } = false;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
