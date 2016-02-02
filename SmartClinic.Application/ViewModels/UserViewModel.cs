using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using System;

namespace SmartClinic.Application.ViewModels
{
    public class UserViewModel
    {
        #region Properties

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(User.LoginMaxLength, MinimumLength = User.LoginMinLength, ErrorMessage = "A quantidade de caracteres no campo Login é invalída")]
        public string Login { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLength, MinimumLength = User.PasswordMinLength, ErrorMessage = "A quantidade de caracteres no campo Senha é invalída")]
        public string Password { get; set; }

        public bool Active { get; set; }

        [Required]
        public UserType UserType { get; set; }

        #endregion

    }
}