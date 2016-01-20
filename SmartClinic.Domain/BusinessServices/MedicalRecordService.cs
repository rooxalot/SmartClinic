using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class MedicalRecordService: IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}