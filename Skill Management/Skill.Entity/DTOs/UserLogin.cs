using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill.Entity.DTOs
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email address")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",ErrorMessage = "Password must be strong")]
        public string Password { get; set; }
    }
}
