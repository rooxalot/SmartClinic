using AutoMapper;
using SmartClinic.Application.ViewModels.UserModels;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            IEnumerable<ValidationResult> errors;
            var isValid = ViewModelValidator.Validate(viewModel, out errors);

            if (isValid)
            {
                viewModel.Password = Encrypter.Encrypt(viewModel.Password);
                using (_unitOfWork)
                {
                    var userAuthenticated = _unitOfWork.UserRepository.GetValidUser(viewModel.Login, viewModel.Password);

                    return userAuthenticated != null;
                }
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var error in errors)
                {
                    sb.AppendLine(error.ToString());
                }

                throw new Exception(sb.ToString());
            }
        }

        public RegisterUserViewModel RegisterUser(RegisterUserViewModel viewModel)
        {
            IEnumerable<ValidationResult> errors;
            var isValid = ViewModelValidator.Validate(viewModel, out errors);

            if (isValid)
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
                var sb = new StringBuilder();
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