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

        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Login form page</returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login User Controller
        /// </summary>
        /// <param name="Creadentials"> Email and Password</param>
        /// <returns> Home Page</returns>
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin Creadentials)
        {

            if (ModelState.IsValid)
            {
                
                bool isLoginSuccess = await _userService.UserLogin(Creadentials);
                if (isLoginSuccess)
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
