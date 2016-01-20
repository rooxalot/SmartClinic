using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Infrastructure.CrossCutting.Validations;
using System;

namespace SmartClinic.Application.AppServices
{
    public class SecretaryAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public SecretaryAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Services

        public Secretary RegisterSecretary(string name, Rg rg, Phone phone, Address address, Sex sex)
        {
            Assertions.AssertArgumentNotNull(name, "Não é possível registrar o secretário. Parâmetro name não pode ser nulo");

            Secretary secretary = new Secretary(name, rg, phone, address, sex);

            using (_unitOfWork)
            {
                _unitOfWork.SecretaryRepository.Add(secretary);
                _unitOfWork.Commit();
            }

            return secretary;
        }

        public void AlterSecretary(Secretary secretary)
        {
            Assertions.AssertArgumentNotNull(secretary, "Não é possível alterar o registro do secretário. Argumento não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.SecretaryRepository.Update(secretary);
                _unitOfWork.Commit();
            }
        }

        public void RemoveSecretary(Guid id)
        {
            using (_unitOfWork)
            {
                var secretary = _unitOfWork.SecretaryRepository.Get(id);
                Assertions.AssertArgumentNotNull(secretary, "Não é possível remover o secretário. Não foi encontrado nenhum registro com o Id informado");

                _unitOfWork.SecretaryRepository.Remove(secretary);
                _unitOfWork.Commit();
            }
        }

        #endregion

    }
}
