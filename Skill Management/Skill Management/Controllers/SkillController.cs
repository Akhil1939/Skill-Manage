using Microsoft.AspNetCore.Mvc;

namespace Skill_Management.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
