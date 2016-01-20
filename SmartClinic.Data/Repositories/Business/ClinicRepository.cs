using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class ClinicRepository : RepositoryBase<Clinic>, IClinicRepository
    {
        public ClinicRepository(SmartClinicContext context) : base(context)
        {
        }
    }
}