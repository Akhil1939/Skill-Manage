using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class UserNotification
    {
        public long NotificationId { get; set; }
        public long UserId { get; set; }
        public string NotificationText { get; set; } = null!;
        public long NotificationType { get; set; }
        public bool? Seen { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DataId { get; set; }

        public virtual NotificationSetting NotificationTypeNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
