using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class WorkoutLogExercise
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid WorkoutLogId { get; set; }

        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public int SetNumber { get; set; }

        [Required]
        public int RepsCompleted { get; set; }

        // Bắt buộc phải có để lưu chính xác mức tạ lẻ (ví dụ: 12.5 kg)
        [Column(TypeName = "decimal(5,2)")]
        public decimal WeightUsed { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual WorkoutLog WorkoutLog { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}