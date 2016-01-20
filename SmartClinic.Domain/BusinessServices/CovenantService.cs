using System;
using System.Collections.Generic;
using System.Linq;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class CovenantService : ICovenantService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public CovenantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        public void GenerateReportByCovenant(Covenant covenant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Covenant> GetAllActiveCovenants(IEnumerable<Covenant> covenants)
        {
            return covenants.Where(c => c.IsActive());
        }
    }
}