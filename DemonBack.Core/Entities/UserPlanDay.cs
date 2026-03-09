using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class UserPlanDay
    {
        public Guid Id { get; set; }

        public Guid UserPlanId { get; set; }
        public UserPlan? UserPlan { get; set; }

        /// <summary>
        /// 1..7
        /// </summary>
        public short DayOfWeek { get; set; }

        /// <summary>
        /// Giờ nhắc cố định (local time)
        /// </summary>
        public TimeOnly NotifyTime { get; set; }

        public bool Enabled { get; set; } = true;

        // Navigation
        public ICollection<UserPlanDayExercise> Exercises { get; set; } = new List<UserPlanDayExercise>();
        public ICollection<WorkoutSchedule> WorkoutSchedules { get; set; } = new List<WorkoutSchedule>();
    }
}
