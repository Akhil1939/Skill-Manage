﻿using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class GoalMission
    {
        public long GoalMissionId { get; set; }
        public long MissionId { get; set; }
        public string? GoalObjectiveText { get; set; }
        public int GoalValue { get; set; }
        public int GoalAchivedValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission Mission { get; set; } = null!;
    }
}
