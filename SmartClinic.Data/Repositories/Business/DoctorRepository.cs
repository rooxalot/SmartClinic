
using System;
using System.Collections.Generic;
using System.Linq;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Data.Repositories.Business
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(SmartClinicContext context)
            : base(context)
        {
        }

        public SmartClinicContext SmartClinicContext => this.Context as SmartClinicContext;

        public IEnumerable<Doctor> GetActiveDoctors()
        {
            return SmartClinicContext.Doctors.Where(d => d.Active)
                .OrderByDescending(d => d.CreatedOn)
                .ToList();
        }
    }
}