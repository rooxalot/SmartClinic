
using SmartClinic.Domain.Entities.Business;
using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Application.ViewModels.UserModels
{
    public class AuthenticateUserViewModel
    {
        [Required]
        [StringLength(User.LoginMaxLength, MinimumLength = User.LoginMinLength, ErrorMessage = "O número de caracteres para o Login está invalido.")]
        public string Login { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLength, MinimumLength = User.PasswordMinLength, ErrorMessage = "O número de caracteres para a Senha está invalido.")]
        public string Password { get; set; }
    }
}
