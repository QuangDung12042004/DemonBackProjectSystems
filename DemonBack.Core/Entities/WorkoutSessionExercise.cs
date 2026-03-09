using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class WorkoutSessionExercise
    {
        public Guid Id { get; set; }

        public Guid SessionId { get; set; }
        public WorkoutSession? Session { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int OrderIndex { get; set; }

        public string? Note { get; set; }

        // Navigation
        public ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
    }
}
