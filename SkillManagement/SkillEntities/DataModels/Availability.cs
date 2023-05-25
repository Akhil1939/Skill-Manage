using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Availability
    {
        public Availability()
        {
            Missions = new HashSet<Mission>();
        }

        public int AvailabilityId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
    }
}
