using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class User
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public long Role { get; set; }
        public long Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Position PositionNavigation { get; set; } = null!;
        public virtual Role RoleNavigation { get; set; } = null!;
    }
}
