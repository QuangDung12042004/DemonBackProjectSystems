using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class WorkoutSession
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? ScheduleId { get; set; }
        public WorkoutSchedule? Schedule { get; set; }

        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? EndedAt { get; set; }

        public string? Note { get; set; }

        // cảm giác buổi tập
        public short? MoodScore { get; set; }      // 1..5
        public short? FatigueScore { get; set; }   // 1..5
        public decimal? SleepHours { get; set; }   // vd: 7.5
        public decimal? SessionRpe { get; set; }   // RPE tổng buổi

        // Navigation
        public ICollection<WorkoutSessionExercise> Exercises { get; set; } = new List<WorkoutSessionExercise>();
    }
}
