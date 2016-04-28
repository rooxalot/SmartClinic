using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using System.Web.Security;

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
            using (_unitOfWork)
            {
                var user = _manager.Authenticate(login, password);
                if (user == null)
                    return false;

                //Adiciona o usuário na sessão
                SessionManager.LoggedUser = user;
                //Autentica o usuário usando FormsAuthentication
                FormsAuthentication.SetAuthCookie(user.Name, false);

                return true;
            }
        }

        public bool HasUserAuthenticated()
        {
            return SessionManager.LoggedUser != null;
        }

        public void LogoutUser()
        {
            if (HasUserAuthenticated())
            {
                SessionManager.LoggedUser = null;
                FormsAuthentication.SignOut();
            }

        }

        #endregion
    }
}
