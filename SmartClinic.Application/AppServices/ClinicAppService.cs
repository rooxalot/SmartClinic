using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;

namespace SmartClinic.Application.AppServices
{
    public class ClinicAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public ClinicAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #endregion

        #region Services

        public Clinic RegisterClinic(string name, string header, Cnpj cnpj, Phone phone)
        {
            Assertions.AssertArgumentNotNull(name, "Não é possível registrar a clinica. O argumento name não pode ser nulo");
            var clinic = new Clinic(name, header, cnpj, phone);

            using (_unitOfWork)
            {
                _unitOfWork.ClinicRepository.Add(clinic);
                _unitOfWork.Commit();
            }

            return clinic;
        }

        public void AlterClinicHeader(Clinic clinic, string header)
        {
            Assertions.AssertArgumentNotNull(clinic, "Não foi possível alterar o cabeçalho da clinica. O argumento clinic não pode ser nulo");
            Assertions.AssertArgumentNotNull(header, "Não foi possível alterar o cabeçalho da clinica. O argumento header não pode ser nulo");

            clinic.SetHeader(header);

            using (_unitOfWork)
            {
                _unitOfWork.ClinicRepository.Update(clinic);
                _unitOfWork.Commit();
            }
        }

        public void RemoveClinic(Guid id)
        {
            using (_unitOfWork)
            {
                var clinic = _unitOfWork.ClinicRepository.Get(id);
                Assertions.AssertArgumentNotNull(clinic, "Não foi possível remover a clinica. Não foi encontrado nenhum registro com o Id informado");

                _unitOfWork.ClinicRepository.Remove(clinic);
                _unitOfWork.Commit();
            }
        }

        #endregion
    }
}