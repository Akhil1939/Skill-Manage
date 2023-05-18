using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs.Skill
{
    public class SkillFilter
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Status { get; set; }  = "All";
        public string? Sort { get; set; } = "New_to_Old";
        public string? Keyword { get; set; } = "";
    }
}
