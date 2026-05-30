using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class WorkoutLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        public Guid? WorkoutDayId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        // Cột này rất lớn (ví dụ tổng tạ 1 buổi đẩy ngực có thể lên tới 5000kg)
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalVolume { get; set; }

        public int FeelingRating { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual WorkoutDay? WorkoutDay { get; set; }
        public virtual ICollection<WorkoutLogExercise> WorkoutLogExercises { get; set; } = new List<WorkoutLogExercise>();
    }
}