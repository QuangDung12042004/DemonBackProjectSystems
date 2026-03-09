using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class AnimePath
    {
        public Guid Id { get; set; }

        public string CharacterName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation
        public ICollection<PathExercise> Exercises { get; set; } = new List<PathExercise>();
        public ICollection<UserPlan> DerivedUserPlans { get; set; } = new List<UserPlan>();
    }
}
