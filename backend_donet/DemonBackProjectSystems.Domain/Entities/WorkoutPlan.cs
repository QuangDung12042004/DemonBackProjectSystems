using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class WorkoutPlan
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PlanName { get; set; }

        [MaxLength(50)]
        public string? Goal { get; set; }

        [MaxLength(50)]
        public string? TargetAnimeBodyStyle { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual ICollection<WorkoutDay> WorkoutDays { get; set; } = new List<WorkoutDay>();
    }
}
