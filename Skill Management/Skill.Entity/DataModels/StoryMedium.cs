﻿using System;
using System.Collections.Generic;

namespace Skill.Entity.DataModels
{
    public partial class StoryMedium
    {
        public long StoryMediaId { get; set; }
        public long StoryId { get; set; }
        public string Type { get; set; } = null!;
        public string? Path { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Story Story { get; set; } = null!;
    }
}
