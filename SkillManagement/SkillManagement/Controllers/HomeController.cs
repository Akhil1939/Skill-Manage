using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SkillManagement.Models;
using System.Diagnostics;

namespace SkillManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature iExceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (iExceptionHandlerFeature != null)
            {
                string path = iExceptionHandlerFeature.Path;
                Exception exception =
                iExceptionHandlerFeature.Error;
                //Write code here to log the exception details
                return View("Error",
                iExceptionHandlerFeature);
            }
            return View();
        }
        [HttpGet("/Error/NotFound/{statusCode}")]
        public IActionResult NotFound(int statusCode)
        {
            var iStatusCodeReExecuteFeature =
            HttpContext.Features.Get
            <IStatusCodeReExecuteFeature>();
            return View("NotFound",
            iStatusCodeReExecuteFeature.OriginalPath);
        }
    }
}