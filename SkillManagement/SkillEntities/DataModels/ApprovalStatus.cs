using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class ApprovalStatus
    {
        public int ApprovalStatusId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
