using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class UserPlanDayExercise
    {
        public Guid Id { get; set; }

        public Guid UserPlanDayId { get; set; }
        public UserPlanDay? UserPlanDay { get; set; }

        public int OrderIndex { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int? TargetSets { get; set; }

        public int? TargetReps { get; set; }

        public decimal? TargetRpe { get; set; }

        public int? RestSeconds { get; set; }
    }
}
