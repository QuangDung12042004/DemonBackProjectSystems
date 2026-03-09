using DemonBack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public decimal? CurrentWeightKg { get; set; }

        public string? Goal { get; set; }

        public UnitType PreferredUnit { get; set; } = UnitType.Kg;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public string? AvatarUrl { get; set; }

        public int CurrentLevel { get; set; } = 1;
        public int CurrentExp { get; set; } = 0;
        public string RankTitle { get; set; } = "E_Rank Hunter";
        public int StreakDays { get; set; } = 0;

        // Navigation
        public ICollection<UserPlan> Plans { get; set; } = new List<UserPlan>();
        public ICollection<WorkoutSchedule> WorkoutSchedules { get; set; } = new List<WorkoutSchedule>();
        public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
        public ICollection<UserBodyLog> BodyLogs { get; set; } = new List<UserBodyLog>();
    }
}
