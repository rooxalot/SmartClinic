using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.CrossCutting;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.DomainServices
{
    public class UserManager : IUserManager
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;

        #endregion

        #region Constructor

        public UserManager(IUnitOfWork unitOfWork, IEncrypter encrypter)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
        }

        #endregion

        #region Services

        /// <summary>
        /// Altera a senha do usuário realizando utilizando-se de criptografia
        /// </summary>
        /// <param name="user">Usuário a ter a senha modificada</param>
        /// <param name="confirmPassword">Confirmação de senha</param>
        /// <param name="newPassword">Nova senha a ser atribuida ao usuário</param>
        /// <returns>Objeto User com a senha alterada</returns>
        public User ChangePassword(User user, string newPassword, string confirmPassword)
        {
            var encryptedConfirmPassword = _encrypter.Encrypt(confirmPassword);
            if (user.Password != encryptedConfirmPassword)
                throw new Exception("A senha informada não coincide com a do usuário");

            var encryptedNewPassword = _encrypter.Encrypt(newPassword);
            user.SetPassword(encryptedNewPassword);

            return user;
        }

        public User Authenticate(string login, string password)
        {
            var encryptedPassword = _encrypter.Encrypt(password);
            var user = _unitOfWork.UserRepository.GetValidUser(login, encryptedPassword);
            return user;
        }

        #endregion
    }
}