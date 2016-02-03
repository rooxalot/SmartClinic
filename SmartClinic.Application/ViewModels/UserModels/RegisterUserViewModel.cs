using SmartClinic.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ViewModels.UserModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(User.LoginMaxLength, MinimumLength = User.LoginMinLength, ErrorMessage = "O número de caracteres para o Login está invalido.")]
        public string Login { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLength, MinimumLength = User.PasswordMinLength, ErrorMessage = "O número de caracteres para a Senha está invalido.")]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public UserType UserType { get; set; }
    }
}
