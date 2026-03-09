using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemonBack.Core.Entities
{
    public class UserBodyLog
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTimeOffset LoggedAt { get; set; } = DateTimeOffset.UtcNow;

        public decimal? WeightKg { get; set; }

        public decimal? MuscleMassKg { get; set; }

        public decimal? BodyFatPercent { get; set; }

        // Số đo 3 vòng (cm) - Optional
        public decimal? ChestSize { get; set; }
        public decimal? WaistSize { get; set; }
        public decimal? ArmSize { get; set; }

        // Ảnh check body
        public string? PhotoFrontUrl { get; set; }
        public string? PhotoBackUrl { get; set; }
    }
}
