using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class SecretaryRepository : RepositoryBase<Secretary>, ISecretaryRepository
    {
        public SecretaryRepository(SmartClinicContext context) : base(context)
        {
        }
    }
}