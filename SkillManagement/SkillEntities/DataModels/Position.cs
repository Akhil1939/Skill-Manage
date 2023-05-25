using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Position
    {
        public Position()
        {
            Users = new HashSet<User>();
        }

        public long PositionId { get; set; }
        public string Position1 { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
