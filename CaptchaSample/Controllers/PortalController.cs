using CaptchaSample.Models;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace CaptchaSample.Controllers
{
    public class PortalController : Controller
    {
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        public PortalController(IDNTCaptchaValidatorService validatorService,
            IOptions<DNTCaptchaOptions> options)
        {
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
                {
                    ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please Enter Valid Captcha.");
                    return View("Login");
                }
            }
            return View();
        }
    }
}
