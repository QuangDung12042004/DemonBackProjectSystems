using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemonBackProjectSystems.Domain.Entities
{
    public class Achievement
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Cột Description trong DB thiết kế là TEXT nên ta không cần giới hạn MaxLength
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? BadgeImageUrl { get; set; }

        [MaxLength(255)]
        public string? RequiredCriteria { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
    }
}