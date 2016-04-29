﻿using SmartClinic.Domain.Entities.Business;
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
        /// Realiza a limpeza de todos os dados presentes na sessão atual e abandona a mesma
        /// </summary>
        /// <returns>Booleano informando se a sessão foi limpa com sucesso</returns>
        public static bool ClearSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();

            return HttpContext.Current.Session.Count == 0;
        }


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
