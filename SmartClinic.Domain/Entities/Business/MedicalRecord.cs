using System;
using SmartClinic.Domain.Entities.Base;

namespace SmartClinic.Domain.Entities.Business
{
    public class MedicalRecord : BaseEntity
    {
        #region Constructor

        //Construtor EntityFramework
        protected MedicalRecord()
        {
        }

        public MedicalRecord(Pacient pacient, string principalComplaining, string possibleDiagnosis, 
            string prescriptedMedication, string exams, string complementaryExams)
        {
            SetPacient(pacient);
            SetPrincipalComplaining(principalComplaining);

            if (possibleDiagnosis == null)
                PossibleDiagnosis = "";
            else
                SetPossibleDiagnosis(PossibleDiagnosis);


            if (prescriptedMedication == null)
                PrescriptedMedication = "";
            else
                SetPrescriptedMedication(prescriptedMedication);


            if (exams == null)
                Exams = "";
            else
                SetExams(exams);


            if (complementaryExams == null)
                ComplementaryExams = "";
            else
                SetComplementaryExams(complementaryExams);

        }

        #endregion

        #region Properties

        public string PrincipalComplaining { get; private set; }
        public string MedicalHistory { get; private set; }
        public string PossibleDiagnosis { get; private set; }
        public string PrescriptedMedication { get; private set; }
        public string Exams { get; private set; }
        public string ComplementaryExams { get; private set; }
        public Guid PacientId { get; private set; }
        public virtual Pacient Pacient { get; private set; }

        #endregion

        #region Constants

        public const int PrincipalComplainingMaxLength = 300;
        public const int MedicalHistoryMaxLength = 300;
        public const int PossibleDiagnosisMaxLength = 300;
        public const int PrescriptedMedicationMaxLength = 300;
        public const int ExamsMaxLength = 500;
        public const int ComplementaryExamsMaxLength = 300;

        #endregion

        #region Methods

        public void SetPacient(Pacient pacient)
        {
            if(pacient == null)
                throw new InvalidOperationException("Ficha médica não pode possuir um paciente nulo");

            Pacient = pacient;
        }

        public void SetPrincipalComplaining(string complain)
        {
            if(complain == null)
                throw new InvalidOperationException("Ficha médica não pode possuir uma queixa nula");

            if(complain.Length > PrincipalComplainingMaxLength)
                throw new InvalidOperationException(string.Format("A queixa do paciente deve possuir no maximo {0} caracteres", PrincipalComplainingMaxLength));


            PrincipalComplaining = complain;
        }

        public void SetMedicalHistory(string medicalHistory)
        {

            if (medicalHistory.Length > MedicalHistoryMaxLength)
                throw new InvalidOperationException(string.Format("O histórico médico do paciente deve possuir no maximo {0} caracteres", MedicalHistoryMaxLength));

            MedicalHistory = medicalHistory;
        }

        public void SetPossibleDiagnosis(string diagnosis)
        {
            if(diagnosis.Length > PossibleDiagnosisMaxLength)
                throw new InvalidOperationException(string.Format("O possível diagnóstico do paciente deve possuir no maximo {0} caracteres", PossibleDiagnosisMaxLength));


            PossibleDiagnosis = diagnosis;
        }

        public void SetPrescriptedMedication(string medication)
        {
            if(medication.Length > PrescriptedMedicationMaxLength)
                throw new InvalidOperationException(string.Format("A medicação prescrita do paciente deve possuir no maximo {0} caracteres", PrescriptedMedicationMaxLength));

            PrescriptedMedication = medication;
        }

        public void SetExams(string exams)
        {
            if(exams.Length > ExamsMaxLength)
                throw new InvalidOperationException(string.Format("Os exames do paciente deve possuir no maximo {0} caracteres", ExamsMaxLength));

            Exams = exams;
        }

        public void SetComplementaryExams(string complementaryExams)
        {
            if(complementaryExams.Length > ComplementaryExamsMaxLength)
                throw new InvalidOperationException(string.Format("Os exames do paciente deve possuir no maximo {0} caracteres", ComplementaryExamsMaxLength));

            ComplementaryExams = complementaryExams;
        }

        #endregion
    }
}