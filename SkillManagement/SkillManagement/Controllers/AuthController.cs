using Microsoft.AspNetCore.Mvc;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillServices;
using SkillServices.IServices;

namespace Skill_Management.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin Creadentials)
        {

            if (ModelState.IsValid)
            {
                
                GenModel<bool> isLoginSuccess = await _userService.UserLogin(Creadentials);
                if (isLoginSuccess.Data)
                {
                    TempData["SuccessMessage"] = "Login Successfull";
                    return RedirectToAction("Home", "Skill");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalide Creadentials";
                    return View(Creadentials);
                }
            }
            return View();

        }
    }
}
