using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class MissionApplication
    {
        public long MissionApplicationId { get; set; }
        public long MissionId { get; set; }
        public long UserId { get; set; }
        public DateTime AppliedAt { get; set; }
        public int ApprovalStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ApprovalStatus ApprovalStatus { get; set; } = null!;
        public virtual Mission Mission { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
