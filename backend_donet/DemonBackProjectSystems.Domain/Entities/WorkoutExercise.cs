using System;
using System.ComponentModel.DataAnnotations;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class WorkoutExercise
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid WorkoutDayId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int OrderIndex { get; set; }

        [Required]
        public int Sets { get; set; }

        [MaxLength(50)]
        public string? Reps { get; set; }

        public int RestSeconds { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual WorkoutDay WorkoutDay { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}