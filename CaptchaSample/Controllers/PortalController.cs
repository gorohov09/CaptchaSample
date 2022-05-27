using CaptchaSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaptchaSample.Controllers
{
    public class PortalController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}
