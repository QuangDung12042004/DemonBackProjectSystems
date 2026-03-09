using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class UserPlan
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? SourcePathId { get; set; }
        public AnimePath? SourcePath { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateOnly StartedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        // Navigation
        public ICollection<UserPlanDay> Days { get; set; } = new List<UserPlanDay>();
    }
}
