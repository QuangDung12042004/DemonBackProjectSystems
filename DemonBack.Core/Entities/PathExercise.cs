using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class PathExercise
    {
        public Guid Id { get; set; }

        public Guid PathId { get; set; }
        public AnimePath? Path { get; set; }

        /// <summary>
        /// 1..7
        /// </summary>
        public short DayOfWeek { get; set; }

        public int OrderIndex { get; set; }

        public Guid ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int? RecommendedSets { get; set; }

        public int? RecommendedReps { get; set; }

        public int? RestSeconds { get; set; }
    }
}
