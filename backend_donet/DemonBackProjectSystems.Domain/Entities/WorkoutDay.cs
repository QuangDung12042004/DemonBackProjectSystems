using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class WorkoutDay
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid WorkoutPlanId { get; set; }

        [Required]
        public int DayNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string DayName { get; set; }

        [MaxLength(100)]
        public string? FocusMuscle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual WorkoutPlan WorkoutPlan { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
        public virtual ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
    }
}