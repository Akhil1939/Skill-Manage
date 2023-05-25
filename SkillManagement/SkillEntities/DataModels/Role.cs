using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public long RoleId { get; set; }
        public string Role1 { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
