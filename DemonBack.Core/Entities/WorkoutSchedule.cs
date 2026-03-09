using DemonBack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class WorkoutSchedule
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? UserPlanDayId { get; set; }
        public UserPlanDay? UserPlanDay { get; set; }

        public DateOnly ScheduledDate { get; set; }

        public TimeOnly ScheduledTime { get; set; }

        public ScheduleStatus Status { get; set; } = ScheduleStatus.Planned;

        public Guid? ParentScheduleId { get; set; }
        public WorkoutSchedule? ParentSchedule { get; set; }

        public string? SuggestionReason { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        // Navigation
        public ICollection<WorkoutSchedule> Reschedules { get; set; } = new List<WorkoutSchedule>();
        public ICollection<WorkoutSession> Sessions { get; set; } = new List<WorkoutSession>();
    }
}
