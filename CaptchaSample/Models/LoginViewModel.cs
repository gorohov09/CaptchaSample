using System.ComponentModel.DataAnnotations;

namespace CaptchaSample.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
