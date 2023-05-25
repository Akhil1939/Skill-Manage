using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class Mission
    {
        public Mission()
        {
            GoalMissions = new HashSet<GoalMission>();
            MissionMedia = new HashSet<MissionMedium>();
            MissionSkills = new HashSet<MissionSkill>();
            Stories = new HashSet<Story>();
        }

        public long MissionId { get; set; }
        public long MissionThemeId { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public string Title { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MissionTypeId { get; set; }
        public bool Status { get; set; }
        public string? OrganizationName { get; set; }
        public string? OrganizationDetail { get; set; }
        public int? AvailabilityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public int? TotalSeats { get; set; }
        public int? AvailableSeats { get; set; }
        public string? WorkingTime { get; set; }

        public virtual Availability? Availability { get; set; }
        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual MissionTheme MissionTheme { get; set; } = null!;
        public virtual ICollection<GoalMission> GoalMissions { get; set; }
        public virtual ICollection<MissionMedium> MissionMedia { get; set; }
        public virtual ICollection<MissionSkill> MissionSkills { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
