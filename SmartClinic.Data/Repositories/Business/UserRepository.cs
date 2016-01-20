using System.Collections.Generic;
using System.Linq;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SmartClinicContext context)
            : base(context)
        {
        }

        public SmartClinicContext SmartClinicContext
        {
            get { return Context as SmartClinicContext; }
        }

        public User GetByLogin(string login)
        {
            var user = SmartClinicContext.Users.FirstOrDefault(u => u.Login == login);
            return user;
        }

        public IEnumerable<User> GetActiveUsers()
        {
            var activeUsers = SmartClinicContext.Users.Where(u => u.Active);

            return activeUsers;
        }

        public User GetValidUser(string login, string password)
        {
            return SmartClinicContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password && u.Active);
        }
    }
}