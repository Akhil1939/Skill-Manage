using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class ContactU
    {
        public long ContactUsId { get; set; }
        public long UserId { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
