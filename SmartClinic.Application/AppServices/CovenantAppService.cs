using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.AppServices
{
    public class CovenantAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CovenantAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region AppService

        public Covenant RegisterCovenant(string name, bool active, DateTime startTerm, DateTime endTerm, string dddPhone, string phoneNumber, string cnpjCode, string offeredPlans)
        {
            var cnpj = cnpjCode == null ? null : new Cnpj(cnpjCode);
            var phone = Phone.CreatePhone(dddPhone, phoneNumber);

            var covenant = new Covenant(name, active, startTerm, endTerm, phone, cnpj, offeredPlans);

            using (_unitOfWork)
            {
                _unitOfWork.CovenantRepository.Add(covenant);
                _unitOfWork.Commit();
            }

            return covenant;
        }

        public void EditCovenant(Covenant covenant)
        {
            using (_unitOfWork)
            {
                _unitOfWork.CovenantRepository.SaveOrAdd(covenant);
                _unitOfWork.Commit();
            }
        }

        public void RemoveCovenant(Guid covenantID)
        {
            using (_unitOfWork)
            {
                var covenant = _unitOfWork.CovenantRepository.Get(covenantID);

                _unitOfWork.CovenantRepository.Remove(covenant);
                _unitOfWork.Commit();
            }
        }

        //TODO: Criar serviço de aplicação para obter o relatório por convenio

        #endregion

    }
}
