using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;

namespace SmartClinic.Application.AppServices
{
    public class UserAppService
    {

        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UserAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Services

        public User RegisterUser(string login, string password, bool active, UserType type)
        {
            Assertions.AssertArgumentNotNull(login, "Login do usuário é obrigatório");
            Assertions.AssertArgumentNotEmpty(login, "Login do usuário é obrigatório");

            Assertions.AssertArgumentNotNull(password, "Senha do usuário é obrigatório");
            Assertions.AssertArgumentNotEmpty(password, "Senha do usuário é obrigatório");

            var encryptedPassword = Encrypter.Encrypt(password);

            var user = new User(login, encryptedPassword, active, type);

            using (_unitOfWork)
            {
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Commit();
            }

            return user;
        }

        public void AlterUser(User user)
        {
            Assertions.AssertArgumentNotNull(user, "Não é possível alterar o usuário. O parâmetro informado não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Commit();
            }
        }

        public void RemoveUser(Guid id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            Assertions.AssertArgumentNotNull(user, "Não é possível remover o usuário. O parâmetro informado não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.UserRepository.Remove(user);
                _unitOfWork.Commit();
            }
        }

        public User AuthenticateUser(string login, string password)
        {
            Assertions.AssertArgumentNotNull(login, "Login obrigatório");
            Assertions.AssertArgumentNotEmpty(login, "Login obrigatório");

            Assertions.AssertArgumentNotNull(password, "Senha obrigatória");
            Assertions.AssertArgumentNotEmpty(password, "Senha obrigatória");

            var encryptedPassword = Encrypter.Encrypt(password);

            using (_unitOfWork)
            {
                var user = _unitOfWork.UserRepository.GetValidUser(login, encryptedPassword);
                return user;
            }
        }

        #endregion
    }
}