using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Comment
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public long MissionId { get; set; }
        public string CommentText { get; set; } = null!;
        public int ApprovalStatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ApprovalStatus ApprovalStatus { get; set; } = null!;
        public virtual Mission Mission { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
