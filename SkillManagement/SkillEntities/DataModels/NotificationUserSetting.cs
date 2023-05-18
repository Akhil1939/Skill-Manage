using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class NotificationUserSetting
    {
        public long NotificationUserSettingsId { get; set; }
        public long UserId { get; set; }
        public long? NotificationSettingsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual NotificationSetting? NotificationSettings { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
