using System.Web;

using SmartClinic.Application.AppModels.User;

namespace SmartClinic.Infrastructure.CrossCutting.Security
{
    public class SessionContext
    {
        
        /// <summary>
        /// Obtem o usuário logado da sessão
        /// </summary>
        public static LoggedUserModel LoggedUser
        {
            get
            {
                return HttpContext.Current.Session["User"] as LoggedUserModel;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

    }
}
