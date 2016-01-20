using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.Repositories.Base;

namespace SmartClinic.Domain.Interfaces.Repositories.Business
{
    public interface IMedicalRecordRepository : IRepositoryBase<MedicalRecord>
    {
        MedicalRecord GetPacientMedicalRecord(Pacient pacient, Guid medicaRecordId);
    }
}