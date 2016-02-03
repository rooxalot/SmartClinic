using AutoMapper;
using SmartClinic.Application.ViewModels.UserModels;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System.Collections.Generic;


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

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = null;
            using (_unitOfWork)
            {
                users = _unitOfWork.UserRepository.GetAll();
            }

            return users;
        }

        public bool AuthenticateUser(AuthenticateUserViewModel viewModel)
        {
            var encryptedPassword = Encrypter.Encrypt(viewModel.Password);
            using (_unitOfWork)
            {
                var userAuthenticated = _unitOfWork.UserRepository.GetValidUser(viewModel.Login, encryptedPassword);

                if (userAuthenticated != null)
                    return true;

                return false;
            }
        }

        public RegisterUserViewModel RegisterUser (RegisterUserViewModel viewModel)
        {
            var isValid = ViewModelValidator.Validate(viewModel);
            if (isValid)
            {
                using (_unitOfWork)
                {
                    var user = Mapper.Map<User>(viewModel);
                    _unitOfWork.UserRepository.SaveOrAdd(user);
                }

                return viewModel;
            }

            return null;
        }

        #endregion
    }
}