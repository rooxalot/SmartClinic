using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.BusinessServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool HasCrmRegistered(Crm crm)
        {
            using (_unitOfWork)
            {
                return _unitOfWork.DoctorRepository.HasCrmRegistered(crm);
            }
        }
    }
}