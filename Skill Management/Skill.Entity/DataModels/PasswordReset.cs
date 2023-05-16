using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class PasswordReset
    {
        public long ResetPasswordId { get; set; }
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
