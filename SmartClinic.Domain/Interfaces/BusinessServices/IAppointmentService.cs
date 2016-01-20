using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.BusinessServices
{
    public interface IAppointmentService
    {
        void TransferAppointment(Appointment appointment, Doctor doctor);
        IEnumerable<Appointment> GetPendingAppointments();
        IEnumerable<Appointment> GetTodayAppointments();
        IEnumerable<Appointment> GetLastSevenDaysAppointments();
        IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor);
    }
}