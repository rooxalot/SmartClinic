using System;
using System.Linq;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.Repositories.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.DomainServices
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorManager(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor SetDoctorCrm(Doctor doctor, Crm crm)
        {
            var crmExists = _doctorRepository
                .Find(d => d.Crm.Code.Equals(crm.Code) && d.Crm.Uf.Equals(crm.Uf) && d.Id != doctor.Id)
                .Any();

            if(crmExists)
                throw new Exception("CRM já existe, não foi possível realizar a associação ao médico.");

            doctor.SetCrm(crm);
            return doctor;

        }
    }
}