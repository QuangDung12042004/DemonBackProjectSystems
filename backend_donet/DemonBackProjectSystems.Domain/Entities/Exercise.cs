using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? MuscleGroup { get; set; }

        [MaxLength(255)]
        public string? SecondaryMuscleGroups { get; set; }

        // Bỏ trống MaxLength vì cột này dự kiến là TEXT (chứa hướng dẫn kỹ thuật dài)
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Difficulty { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [MaxLength(500)]
        public string? VideoUrl { get; set; }

        [MaxLength(500)]
        public string? AnimeReferenceImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
        public virtual ICollection<WorkoutLogExercise> WorkoutLogExercises { get; set; } = new List<WorkoutLogExercise>();
    }
}