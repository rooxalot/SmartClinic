using SmartClinic.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartClinic.Infrastructure.CrossCutting.Security
{
    public class SessionManager
    {
        /// <summary>
        /// Obtem o usuário logado na aplicação
        /// </summary>
        public static User LoggedUser
        {
            get
            {
                return HttpContext.Current.Session["User"] as User;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }
    }
}
