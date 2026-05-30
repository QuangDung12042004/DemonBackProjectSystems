using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class UserProfile
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(500)]
        public string? AvatarUrl { get; set; }

        public int? Age { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Height { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Weight { get; set; }

        [MaxLength(50)]
        public string? Goal { get; set; }

        [MaxLength(50)]
        public string? TrainingLevel { get; set; }

        public int? DaysPerWeek { get; set; }

        [MaxLength(50)]
        public string? TargetAnimeBodyStyle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
