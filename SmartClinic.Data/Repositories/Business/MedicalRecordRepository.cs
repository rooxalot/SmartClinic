using System;
using System.Linq;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Data.Repositories.Business
{
    public class MedicalRecordRepository : RepositoryBase<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(SmartClinicContext context) 
            : base(context)
        {
        }

        public SmartClinicContext SmartClinicContext => Context as SmartClinicContext;

        public MedicalRecord GetPacientMedicalRecord(Pacient pacient, Guid medicaRecordId)
        {
            return SmartClinicContext.MedicalRecords
                .FirstOrDefault(mr => mr.PacientId == pacient.Id && mr.Id == medicaRecordId);
        }
    }
}