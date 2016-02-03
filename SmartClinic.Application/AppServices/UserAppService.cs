using AutoMapper;
using SmartClinic.Application.ViewModels.UserModels;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;
using System.Collections.Generic;
using System.Text;


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
            var errors = ViewModelValidator.Validate(viewModel);
            if (errors == null || errors.Count <= 0)
            {
                using (_unitOfWork)
                {
                    viewModel.Password = Encrypter.Encrypt(viewModel.Password);
                    var user = Mapper.Map<User>(viewModel);

                    _unitOfWork.UserRepository.SaveOrAdd(user);
                    _unitOfWork.Commit();
                }

                return viewModel;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in errors)
                {
                    sb.AppendLine(error.ToString());
                }

                throw new Exception(sb.ToString());
            }
        }

        #endregion
    }
}