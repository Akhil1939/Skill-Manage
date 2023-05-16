using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class MissionType
    {
        public int MissionTypeId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
