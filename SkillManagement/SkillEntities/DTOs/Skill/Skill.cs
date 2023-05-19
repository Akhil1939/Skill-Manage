using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs.Skill
{
    public class Skill
    {
        /// <summary>
        /// Skill Id
        /// </summary>
        [Required(ErrorMessage = "Skill Id Is Required")]
        public long SkillId { get; set; }

        /// <summary>
        /// Skill Name
        /// </summary>
        [Required(ErrorMessage = "Skill Name Is Required")]
        public string SkillName { get; set; }

        /// <summary>
        /// Skill Status
        /// </summary>
        [Required(ErrorMessage = "Skill Status Is Required")]
        public int Status { get; set; }
    }
}
