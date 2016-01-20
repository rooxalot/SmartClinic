using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class CovenantRepository : RepositoryBase<Covenant>, ICovenantRepository
    {
        public CovenantRepository(SmartClinicContext context) : base(context)
        {
        }
    }
}