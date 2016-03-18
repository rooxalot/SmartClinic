using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.CrossCutting;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Domain.DomainServices
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserManager(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }


        /// <summary>
        /// Altera a senha do usuário realizando utilizando-se de criptografia
        /// </summary>
        /// <param name="user">Usuário a ter a senha modificada</param>
        /// <param name="confirmPassword">Confirmação de senha</param>
        /// <param name="newPassword">Nova senha a ser atribuida ao usuário</param>
        /// <returns></returns>
        public User ChangePassword(User user, string confirmPassword, string newPassword)
        {
            var encryptedConfirmPassword = _encrypter.Encrypt(confirmPassword);
            if (user.Password != encryptedConfirmPassword)
                throw new Exception("A senha informada não coincide com a do usuário");

            var encryptedNewPassword = _encrypter.Encrypt(newPassword);
            user.SetPassword(encryptedNewPassword);

            return user;
        }
    }
}