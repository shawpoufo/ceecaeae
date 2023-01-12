using Artisanal.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Artisanal.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("se")]
        public JsonResult Secrecte()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;

            return new JsonResult(new { id, role, isHibou = HttpContext.User.IsInRole("hibou"),cookie=HttpContext.Request.Cookies });
        }
    }
}