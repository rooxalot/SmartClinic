using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Infrastructure.CrossCutting.Validations;

namespace SmartClinic.Application.AppServices
{
    public class PacientAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPacientService _pacientService;

        #endregion

        #region Constructor

        public PacientAppService(IUnitOfWork unitOfWork, IPacientService pacientService)
        {
            _unitOfWork = unitOfWork;
            _pacientService = pacientService;
        }

        #endregion

        #region Services

        public Pacient RegisterPacient(string name, Address address, Phone phone, Rg rg, Sex sex, Covenant covenant)
        {
            Assertions.AssertArgumentNotNull(name, "Não é possível cadastrar o paciente. O argumento name não pode ser nulo");
            var pacient = new Pacient(name, address, phone, rg, sex, covenant);

            using (_unitOfWork)
            {
                _unitOfWork.PacientRepository.Add(pacient);
                _unitOfWork.Commit();
            }

            return pacient;
        }

        public void AlterPacientPersonalInfo(Pacient pacient)
        {
            Assertions.AssertArgumentNotNull(pacient, "Não é possível alterar o paciente. O argumento pacient não pode ser nulo");

            _pacientService.AlterPacientPersonalInfo(pacient);
        }

        public void AlterPacientMedicalRecord(Pacient pacient, MedicalRecord medicalRecord)
        {
            _pacientService.AlterPacientMedicalRecord(pacient, medicalRecord);
        }

        public void RemovePacient(Guid id)
        {
            using (_unitOfWork)
            {
                var pacient = _unitOfWork.PacientRepository.Get(id);
                Assertions.AssertArgumentNotNull(pacient, "Não é possível remover o paciente. Não foi encontrado nenhum registro com o Id informado");

                _unitOfWork.PacientRepository.Remove(pacient);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Pacient> GetPacientsByName(string name)
        {
            return _pacientService.GetPacientsByName(name);
        }

        #endregion
    }
}