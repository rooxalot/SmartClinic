using SmartClinic.Domain.Entities.Business;
using System.Collections.Generic;

namespace SmartClinic.Domain.Interfaces.DomainServices
{
    public interface IAppointmentManager
    {
        Appointment SetAppointmentCovenant(Appointment appointment, Covenant covenant);
        Appointment SetAppointmentDoctor(Appointment appointment, Doctor doctor);
        IEnumerable<Appointment> GetPendingAppointments(int days = 0);
    }
}