using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.AppServices
{
    public class UserAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _manager;

        public UserAppService(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _manager = userManager;
        }

        public bool Authenticate(string login, string password)
        {
            var user = _manager.Authenticate(login, password);

            return (user != null);
        } 
    }
}
