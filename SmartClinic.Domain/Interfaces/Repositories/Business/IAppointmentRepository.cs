using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Base;

namespace SmartClinic.Domain.Interfaces.Repositories.Business
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor);
        IEnumerable<Appointment> GetPendingAppointments(int days = 0);

        IEnumerable<Appointment> GetAppointmentsWithinDateRange(DateTime start, DateTime end);
    }
}