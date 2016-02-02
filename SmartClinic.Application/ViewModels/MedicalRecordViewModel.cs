using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ViewModels
{
    public class MedicalRecordViewModel
    {

        #region Properties

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(MedicalRecord.ComplementaryExamsMaxLength, ErrorMessage = "A quantidade de caracteres no campo Queixa não é valída")]
        public string PrincipalComplaining { get; set; }

        [StringLength(MedicalRecord.MedicalHistoryMaxLength, ErrorMessage = "A quantidade de caracteres no campo Histórico Médico não é valida")]
        public string MedicalHistory { get; set; }

        [StringLength(MedicalRecord.PossibleDiagnosisMaxLength, ErrorMessage = "A quantidade de caracteres no campo Possível Diagnóstico não é valida")]
        public string PossibleDiagnosis { get; set; }

        [StringLength(MedicalRecord.PrescriptedMedicationMaxLength, ErrorMessage = "A quantidade de caracteres no campo Medicação Prescrita não é valida")]
        public string PrescriptedMedication { get; set; }

        [StringLength(MedicalRecord.ExamsMaxLength, ErrorMessage = "A quantidade de caracteres no campo Exames não é valida")]
        public string Exams { get; set; }

        [StringLength(MedicalRecord.PrescriptedMedicationMaxLength, ErrorMessage = "A quantidade de caracteres no campo Exames Complementares não é valida")]
        public string ComplementaryExams { get; set; }

        [ScaffoldColumn(false)]
        public Guid PacientId { get; set; }

        [ScaffoldColumn(false)]
        public virtual PacientViewModel Pacient { get; set; }

        #endregion
    }
}