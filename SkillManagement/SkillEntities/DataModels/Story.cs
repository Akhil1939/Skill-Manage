using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Story
    {
        public Story()
        {
            StoryInvites = new HashSet<StoryInvite>();
            StoryMedia = new HashSet<StoryMedium>();
        }

        public long StoryId { get; set; }
        public long MissionId { get; set; }
        public long UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int StoryStatusId { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Mission Mission { get; set; } = null!;
        public virtual StoryStatus StoryStatus { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<StoryInvite> StoryInvites { get; set; }
        public virtual ICollection<StoryMedium> StoryMedia { get; set; }
    }
}
