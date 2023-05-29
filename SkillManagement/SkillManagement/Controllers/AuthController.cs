using DemoMvcCore.Auth;
using DemoMvcCore.Entities.Auth;
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
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        #region Login

        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Login form page</returns>
        [HttpGet]
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
               
                
                User user = await _userService.UserLogin(Creadentials);
                if (user != null)
                {
                    TempData["SuccessMessage"] = "Login Successfull";
                    //HttpContext.Session.SetString("Login", "true");
                    var jwtSettings = _configuration.GetSection(nameof(JwtSetting)).Get<JwtSetting>();

                    var token = JwtTokenHelper.GenerateToken(jwtSettings, user);
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1), // Set the expiration date/time for the cookie
                        HttpOnly = true, // Ensure the cookie is accessible only through HTTP (not JavaScript)
                        Secure = true, // Require HTTPS to send the cookie
                        SameSite = SameSiteMode.Strict // Enforce strict same-site policy for the cookie
                    };
                    //HttpContext.Session.SetString("Token", token);
                    Response.Cookies.Append("token", token, cookieOptions);
                    return RedirectToAction("Home", "Skill");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalide Creadentials";
                    return View(Creadentials);
                }
            }
            return View(Creadentials);

        }
        #endregion

        #region Register
        public async Task<IActionResult> Register()
        {
            return View();
        }
        #endregion

        #region Logout
        [HttpPost]
        public   IActionResult Logout()
        {
            if(Request.Cookies["token"] != null)
            {

            Response.Cookies.Delete("token");
            }
           
            TempData["SuccessMessage"] = "Logout Successfull";
            return RedirectToAction("Login");
        }
        #endregion
    }
}