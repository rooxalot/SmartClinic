using System;
using System.Collections.Generic;
using System.Linq;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class AppoitmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppoitmentRepository(SmartClinicContext context) 
            : base(context)
        {
        }

        public SmartClinicContext SmartClinicContext => Context as SmartClinicContext;

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
        {
            using (SmartClinicContext)
            {
                return SmartClinicContext.Appointments
                    .Where(a => a.DoctorId == doctor.Id)
                    .ToList();
            }
        }

        public IEnumerable<Appointment> GetAppointmentsWithinDateRange(DateTime start, DateTime end)
        {
            using (SmartClinicContext)
            {
                return SmartClinicContext.Appointments
                    .Where(a => a.Date.Date >= start.Date && a.Date.Date <= end.Date)
                    .ToList();
            }
        }

        public IEnumerable<Appointment> GetPendingAppointments(int days = 0)
        {
            using (SmartClinicContext)
            {
                if(days > 0)
                    return SmartClinicContext.Appointments
                    .Where(a => a.IsPending() && a.Date <= DateTime.Now.AddDays(days))
                    .ToList();

                return SmartClinicContext.Appointments
                    .Where(a => a.IsPending())
                    .ToList();
            }
        }
    }
}