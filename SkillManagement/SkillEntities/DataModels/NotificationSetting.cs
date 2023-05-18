using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class NotificationSetting
    {
        public NotificationSetting()
        {
            NotificationUserSettings = new HashSet<NotificationUserSetting>();
            UserNotifications = new HashSet<UserNotification>();
        }

        public long NotificationSettingsId { get; set; }
        public string NotificationSettingsOptions { get; set; } = null!;
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<NotificationUserSetting> NotificationUserSettings { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
