using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillEntities.DTOs
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public long Role { get; set; }
        public long Position { get; set; }
    }
}
