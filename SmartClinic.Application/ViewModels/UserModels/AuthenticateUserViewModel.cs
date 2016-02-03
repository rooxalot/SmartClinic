
using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Application.ViewModels.UserModels
{
    public class AuthenticateUserViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
