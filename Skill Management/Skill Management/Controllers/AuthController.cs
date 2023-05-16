using Microsoft.AspNetCore.Mvc;
using Skill.Entity.DTOs;

namespace Skill_Management.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(UserLogin LoginData)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Home", "Skill");
            }
            else { 
            
            return View();
            }
        }
    }
}
