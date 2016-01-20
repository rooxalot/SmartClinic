using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.BusinessServices
{
    public interface ICovenantService
    {
        IEnumerable<Covenant> GetAllActiveCovenants(IEnumerable<Covenant> covenants);
        void GenerateReportByCovenant(Covenant covenant);
    }
}