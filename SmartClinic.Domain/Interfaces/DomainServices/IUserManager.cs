using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.DomainServices
{
    public interface IUserManager
    {
        User Authenticate(string login, string password);
        User ChangePassword(User user, string currentPassword, string newPassword);
    }
}