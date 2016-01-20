using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Domain.Interfaces.BusinessServices
{
    public interface IPacientService
    {
        void AlterPacientPersonalInfo(Pacient pacient);
        void AlterPacientMedicalRecord(Pacient pacient, MedicalRecord medicalRecord);
        IEnumerable<Pacient> GetPacientsByName(string name);
    }
}