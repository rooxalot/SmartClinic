using System;
using System.Collections.Generic;
using AutoMapper;
using SmartClinic.Application.ViewModels;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Infrastructure.CrossCutting.Validations;

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

        public IEnumerable<DoctorViewModel> GetDoctors()
        {
            using (_unitOfWork)
            {
                var doctors = _unitOfWork.DoctorRepository.GetAll();

                return Mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            }
        }

        public Doctor RegisterDoctor(string name, Rg rg, Crm crm, bool active, Sex sex, Address address)
        {
            Assertions.AssertArgumentNotNull(name, "Não foi possível cadastrar o médico. Argumento name não pode ser nulo");
            Assertions.AssertArgumentNotNull(name, "Não foi possível cadastrar o médico. Argumento crm não pode ser nulo");

            if (_doctorService.HasCrmRegistered(crm))
                throw new InvalidOperationException("Não é possível cadastrar o médico com este CRM pois o mesmo já existe");

            var doctor = new Doctor(name, rg, crm, active, sex, address);

            using (_unitOfWork)
            {
                _unitOfWork.DoctorRepository.Add(doctor);
                _unitOfWork.Commit();
            }

            return doctor;
        }

        public void AlterDoctor(Doctor doctor)
        {
            Assertions.AssertArgumentNotNull(doctor, "Não é possivel alterar o registro do médico. Argumento doctor não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.DoctorRepository.Add(doctor);
                _unitOfWork.Commit();
            }
        }

        public void RemoveDoctor(Guid id)
        {
            using (_unitOfWork)
            {
                var doctor = _unitOfWork.DoctorRepository.Get(id);
                Assertions.AssertArgumentNotNull(doctor, "Não é possível remover o médico. Não foi encontrado nenhum registro com o Id informado");

                _unitOfWork.DoctorRepository.Remove(doctor);
                _unitOfWork.Commit();
            }
        }

        #endregion

    }
}