using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class MedicalRecordConfig : EntityTypeConfiguration<MedicalRecord>
    {
        public MedicalRecordConfig()
        {
            //Primary Key
            HasKey(m => m.Id);

            //Foreign Key
            HasRequired(m => m.Pacient) //A Entidade Pacient é obrigatória para MedicalRecord
                .WithMany() // Um Pacient pode possuir vários MedicalRecords
                .HasForeignKey(m => m.PacientId); // A Foreign Key que associa um Pacient a um MedicalRecord é PacientId

            //Table Configuration
            Property(m => m.PrincipalComplaining)
                .IsRequired()
                .HasMaxLength(MedicalRecord.PrincipalComplainingMaxLength);

            Property(m => m.MedicalHistory)
                .HasMaxLength(MedicalRecord.MedicalHistoryMaxLength);

            Property(m => m.PossibleDiagnosis)
                .HasMaxLength(MedicalRecord.PossibleDiagnosisMaxLength);

            Property(m => m.PrescriptedMedication)
                .HasMaxLength(MedicalRecord.PrescriptedMedicationMaxLength);

            Property(m => m.Exams)
                .HasMaxLength(MedicalRecord.ExamsMaxLength);

            Property(m => m.ComplementaryExams)
                .HasMaxLength(MedicalRecord.ComplementaryExamsMaxLength);
        }
    }
}