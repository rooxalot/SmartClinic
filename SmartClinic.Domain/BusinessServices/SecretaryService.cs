using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class SecretaryService : ISecretaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecretaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}