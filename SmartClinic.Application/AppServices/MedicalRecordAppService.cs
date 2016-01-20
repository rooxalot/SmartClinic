using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Validations;

namespace SmartClinic.Application.AppServices
{
    public class MedicalRecordAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public MedicalRecordAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Services

        public MedicalRecord CreateMedicalRecord(Pacient pacient, string principalComplaining,
            string possibleDiagnosis, string prescriptedMedication, string exams, string complementaryExams)
        {
            var medicalRecord = new MedicalRecord(pacient, principalComplaining, possibleDiagnosis,
                prescriptedMedication, exams, complementaryExams);

            using (_unitOfWork)
            {
                _unitOfWork.MedicalRecordRepository.Add(medicalRecord);
                _unitOfWork.Commit();
            }

            return medicalRecord;
        }

        public void RemoveMedicalRecord(Guid id)
        {
            using (_unitOfWork)
            {
                var medicalRecord = _unitOfWork.MedicalRecordRepository.Get(id);
                Assertions.AssertArgumentNotNull(medicalRecord, "Não foi possível remover a ficha médica. Não foi encontrado nenhum registro com o Id informado");

                _unitOfWork.MedicalRecordRepository.Remove(medicalRecord);
                _unitOfWork.Commit();
            }
        }

        #endregion
    }
}