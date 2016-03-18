using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Interfaces.DomainServices
{
    public interface IDoctorManager
    {
        Doctor SetDoctorCrm(Doctor doctor, Crm crm);
    }
}