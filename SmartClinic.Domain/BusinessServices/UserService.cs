
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}