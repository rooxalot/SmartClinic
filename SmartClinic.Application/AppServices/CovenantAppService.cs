using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Infrastructure.CrossCutting.Validations;


namespace SmartClinic.Application.AppServices
{
    public class CovenantAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICovenantService _covenantService;

        #endregion

        #region Constructor

        public CovenantAppService(IUnitOfWork unitOfWork, ICovenantService covenantService)
        {
            _unitOfWork = unitOfWork;
            _covenantService = covenantService;
        }

        #endregion

        #region Services

        public Covenant RegisterCovenantWithOfferedPlans(string name, bool active, DateTime startTerm, DateTime endTerm,
            Phone phone, Cnpj cnpj, string offeredPlans)
        {
            Assertions.AssertArgumentNotNull(name, "Não é possível cadastrar o convênio. O argumento name não pode ser nulo");
            var covenant = new Covenant(name, active, startTerm, endTerm, phone, cnpj, offeredPlans);

            using (_unitOfWork)
            {
                _unitOfWork.CovenantRepository.Add(covenant);
                _unitOfWork.Commit();
            }

            return covenant;
        }

        public Covenant RegisterCovenantWithoutOfferedPlans(string name, bool active, DateTime startTerm,
            DateTime endTerm, Phone phone, Cnpj cnpj)
        {
            return RegisterCovenantWithOfferedPlans(name, active, startTerm, endTerm, phone, cnpj, null);
        }

        public void AlterCovenant(Covenant covenant)
        {
            Assertions.AssertArgumentNotNull(covenant, "Não é possível alterar o convênio. O Argumento covenant não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.CovenantRepository.Update(covenant);
                _unitOfWork.Commit();
            }
        }

        public void RemoveCovenant(Guid id)
        {
            using (_unitOfWork)
            {
                var covenant = _unitOfWork.CovenantRepository.Get(id);
                Assertions.AssertArgumentNotNull(covenant, "Não é possível remover o convenio. Não há nenhum registro com o Id informado");

                _unitOfWork.CovenantRepository.Remove(covenant);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Covenant> GetAllActiveCovenants()
        {
            using (_unitOfWork)
            {
                return  _covenantService.GetAllActiveCovenants(_unitOfWork.CovenantRepository.GetAll());
            }
        }

        #endregion

    }
}
