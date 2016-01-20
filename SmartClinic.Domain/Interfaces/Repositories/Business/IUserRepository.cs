using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Base;

namespace SmartClinic.Domain.Interfaces.Repositories.Business
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByLogin(string login);
        IEnumerable<User> GetActiveUsers();
        User GetValidUser(string login, string password);
    }
}