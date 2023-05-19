using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs
{
    public class SkillListing
    {
        /// <summary>
        /// Skill Id
        /// </summary>
        public long SkillId { get; set; }

        /// <summary>
        /// Skill Name
        /// </summary>
        public string SkillName { get; set;}

        /// <summary>
        /// Skill Status
        /// </summary>
        public int Status { get; set; }
    }
}
