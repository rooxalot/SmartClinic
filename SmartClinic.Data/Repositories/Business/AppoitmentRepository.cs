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
        #region Constructor

        public AppoitmentRepository(SmartClinicContext context)
            : base(context)
        {
        }

        #endregion
        
        #region Context

        public SmartClinicContext SmartClinicContext => Context as SmartClinicContext;

        #endregion

        #region Methods

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

        #endregion
    }
}