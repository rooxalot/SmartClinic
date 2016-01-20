using System;

namespace SmartClinic.MVC.ViewModels
{
    public class MedicalRecordViewModel
    {

        #region Properties

        public string PrincipalComplaining { get; private set; }
        public string MedicalHistory { get; private set; }
        public string PossibleDiagnosis { get; private set; }
        public string PrescriptedMedication { get; private set; }
        public string Exams { get; private set; }
        public string ComplementaryExams { get; private set; }
        public Guid PacientId { get; private set; }
        public virtual PacientViewModel Pacient { get; private set; }

        #endregion
    }
}