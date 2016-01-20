using SmartClinic.Domain.Enums;
using System;

namespace SmartClinic.MVC.ViewModels
{
    public class UserViewModel
    {
        #region Properties

        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }
        public UserType UserType { get; private set; }

        #endregion

    }
}