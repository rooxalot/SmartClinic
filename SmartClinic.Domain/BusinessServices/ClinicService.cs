using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClinicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}