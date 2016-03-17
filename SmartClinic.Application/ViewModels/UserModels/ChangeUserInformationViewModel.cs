using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;

namespace SmartClinic.Application.ViewModels.UserModels
{
    public class ChangeUserInformationViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(User.LoginMaxLength, MinimumLength = User.LoginMinLength, ErrorMessage = "O número de caracteres para o Login está invalido.")]
        public string Login { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLength, MinimumLength = User.PasswordMinLength, ErrorMessage = "O número de caracteres para a Senha está invalido.")]
        public string Password { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLength, MinimumLength = User.PasswordMinLength, ErrorMessage = "O número de caracteres para a Nova Senha está invalido.")]
        public string NewPassword { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public UserType UserType { get; set; }
    }
}