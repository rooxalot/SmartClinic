using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.Enums;

namespace SmartClinic.Domain.Entities.Business
{
    public class User : BaseEntity
    {
        #region Constructor

        /*Construtor EntityFramework*/

        protected User()
        {
        }

        public User(string login, string password, bool active, UserType type)
        {
            SetLogin(login);
            SetPassword(password);
            Active = active;
            UserType = type;
        }

        #endregion

        #region Properties

        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }
        public UserType UserType { get; set; }

        #endregion

        #region Constants

        public const int LoginMinLength = 4;
        public const int LoginMaxLength = 30;

        public const int PasswordMinLength = 4;
        public const int PasswordMaxLength = 60;

        #endregion

        #region Methods

        public void SetPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
                throw new InvalidOperationException("Senha não pode ser nula ou vazia");
            
            if(password.Length < PasswordMinLength || password.Length > PasswordMaxLength)
                throw new InvalidOperationException(string.Format("A senha deve possuir entre {0} a {1} caracteres", PasswordMinLength, PasswordMaxLength));

            Password = password;
        }

        public void SetLogin(string login)
        {
            if(string.IsNullOrEmpty(login))
                throw new InvalidOperationException("Login não pode ser nulo ou vazio");

            if(login.Length < LoginMinLength || login.Length > LoginMaxLength)
                throw new InvalidOperationException(string.Format("O Login deve possuir entre {0} a {1} caracteres", LoginMinLength, LoginMaxLength));

            Login = login;
        }

        #endregion
    }
}