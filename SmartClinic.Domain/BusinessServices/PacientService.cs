using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class PacientService : IPacientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PacientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void AlterPacientMedicalRecord(Pacient pacient, MedicalRecord medicalRecord)
        {
            if(pacient == null)
                throw new ArgumentNullException("pacient");

            if(medicalRecord == null)
                throw new ArgumentNullException("medicalRecord");

            using (_unitOfWork)
            {
                var record = 
                    _unitOfWork.MedicalRecordRepository.GetPacientMedicalRecord(pacient, medicalRecord.Id);

                if(record == null)
                    throw new InvalidOperationException("Não foi encontrado a ficha médica para este paciente");

                _unitOfWork.MedicalRecordRepository.Update(medicalRecord);
                _unitOfWork.Commit();
            }
        }

        public void AlterPacientPersonalInfo(Pacient pacient)
        {
            using (_unitOfWork)
            {
                _unitOfWork.PacientRepository.Update(pacient);
                _unitOfWork.Commit();
            }
        }

        public IEnumerable<Pacient> GetPacientsByName(string name)
        {
            if (name == null)
                throw new InvalidOperationException("Não foi possível obter os pacientes por nome devido o valor " +
                                                    "passado para a consulta ser nulo");

            using (_unitOfWork)
            {
                return _unitOfWork.PacientRepository.GetPacientsByName(name);
            }
        }
    }
}