using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class ProgressLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BodyFatPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Chest { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Waist { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Arm { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Leg { get; set; }

        // Cột quan trọng để track form V-taper
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Shoulder { get; set; }

        [MaxLength(500)]
        public string? FrontPhotoUrl { get; set; }

        [MaxLength(500)]
        public string? BackPhotoUrl { get; set; }

        [MaxLength(500)]
        public string? SidePhotoUrl { get; set; }

        // Note cứ để trống MaxLength vì user có thể viết nhật ký dài
        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual User User { get; set; }
    }
}