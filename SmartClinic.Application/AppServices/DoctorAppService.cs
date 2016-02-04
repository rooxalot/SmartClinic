using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SmartClinic.Application.ViewModels.DoctorModels;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;
using AutoMapper;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.AppServices
{
    public class DoctorAppService
    {

        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorService _doctorService;

        #endregion

        #region Constructor

        public DoctorAppService(IUnitOfWork unitOfWork, IDoctorService doctorService)
        {
            _unitOfWork = unitOfWork;
            _doctorService = doctorService;
        }

        #endregion

        #region Services

        //teste
        public List<RegisterDoctorViewModel> GetModels()
        {
            return Mapper.Map<List<RegisterDoctorViewModel>>(_unitOfWork.DoctorRepository.GetAll());
        }

        public RegisterDoctorViewModel RegisterDoctor(RegisterDoctorViewModel viewModel)
        {
            IEnumerable<ValidationResult> errors;
            var isValid = ViewModelValidator.Validate(viewModel, out errors);

            if (isValid)
            {
                var doctor = Mapper.Map<Doctor>(viewModel);
                var crmExists = _doctorService.HasCrmRegistered(doctor.Crm);

                if (!crmExists)
                {
                    using (_unitOfWork)
                    {
                        _unitOfWork.DoctorRepository.SaveOrAdd(doctor);
                        _unitOfWork.Commit();
                    }

                    return viewModel;
                }
                else
                    throw new Exception("O CRM cadastrado já existe. Não é possível realizar o cadastro do médico");

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