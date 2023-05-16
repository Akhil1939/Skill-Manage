using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class MissionSkill
    {
        public long MissionSkillId { get; set; }
        public long MissionId { get; set; }
        public long SkillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission Mission { get; set; } = null!;
        public virtual Skill Skill { get; set; } = null!;
    }
}
