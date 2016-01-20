
using System;
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

        public SmartClinicContext SmartClinicContext => Context as SmartClinicContext;

        public bool HasCrmRegistered(Crm crm)
        {
            using (SmartClinicContext)
            {
                var doctorCrmRegistered = SmartClinicContext
                    .Doctors
                    .FirstOrDefault(d => d.Crm.Code == crm.Code && d.Crm.Uf == crm.Uf);

                return doctorCrmRegistered != null;
            }
        }
    }
}