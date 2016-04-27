using SmartClinic.Application.AppModels.User;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;

namespace SmartClinic.Application.AppServices
{
    public class UserAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager _manager;

        #endregion

        #region Constructor

        public UserAppService(IUnitOfWork unitOfWork, IUserManager userManager)
        {
            _unitOfWork = unitOfWork;
            _manager = userManager;
        }

        #endregion

        #region AppServices

        public bool Authenticate(string login, string password)
        {
            bool logged = false;
            using (_unitOfWork)
            {
                var user = _manager.Authenticate(login, password);
                if (user == null)
                    return logged;

                SessionManager.LoggedUser = user;
                logged = true;

                return logged;
            }
        }

        public bool HasUserAuthenticated()
        {
            return SessionManager.LoggedUser != null;
        }

        public void LogoutUser()
        {
            if (HasUserAuthenticated())
                SessionManager.LoggedUser = null;

        }

        #endregion
    }
}
