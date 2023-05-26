using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs.Skill
{
    public class SkillFilter
    {
        /// <summary>
        /// Page No
        /// </summary>
        public int PageNo { get; set; } = 1;
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; } = 6;

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }  = "All";

        /// <summary>
        /// Sort
        /// </summary>
        public string? Sort { get; set; } = "New_to_Old";

        /// <summary>
        /// Keyword
        /// </summary>
        public string? Keyword { get; set; } = "";
    }
}
