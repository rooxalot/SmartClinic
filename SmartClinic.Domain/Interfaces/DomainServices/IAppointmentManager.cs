using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.DomainServices
{
    public interface IAppointmentManager
    {
        Appointment SetAppointmentCovenant(Appointment appointment, Covenant covenant);
        Appointment SetAppointmentDoctor(Appointment appointment, Doctor doctor);
    }
}