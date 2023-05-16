using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class StoryStatus
    {
        public StoryStatus()
        {
            Stories = new HashSet<Story>();
        }

        public int StoryStatusId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}
