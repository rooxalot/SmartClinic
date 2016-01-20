using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Interfaces.BusinessServices
{
    public interface IDoctorService
    {
        bool HasCrmRegistered(Crm crm);
    }
}