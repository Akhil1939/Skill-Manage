using System;
using System.Collections.Generic;

namespace SkillEntities.DataModels
{
    public partial class City
    {
        public City()
        {
            Missions = new HashSet<Mission>();
            Users = new HashSet<User>();
        }

        public long CityId { get; set; }
        public long? CountryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
