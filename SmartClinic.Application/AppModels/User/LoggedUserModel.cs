using SmartClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartClinic.Application.AppModels.User
{
    public class LoggedUserModel
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
    }
}