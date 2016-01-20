using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class AppointmentConfig : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfig()
        {
            //Primary Key
            HasKey(a => a.Id);

            //Foreign Keys
            HasRequired(a => a.Doctor) // A Propriedade Doctor da entidade Appointment é obrigatória 
                .WithMany() // Um Doctor pode possuir varios Appointments
                .HasForeignKey(a => a.DoctorId);
                // A propriedade que referencia Doctor em Appointments se chama DoctorId

            HasRequired(a => a.Pacient) // A Propriedade Pacient da entidade Appointment é obrigatória 
                .WithMany(). // Um Pacient pode possuir varios Appointments 
                HasForeignKey(a => a.PacientId);
                // A propriedade que referencia Pacient em Appointments se chama DoctorId

            HasRequired(a => a.Covenant) // A Propriedade Convenant da entidade Appointment é obrigatória
                .WithMany() // Um Covenant pode possui vários Appointments
                .HasForeignKey(a => a.ConvenantId);
                // A propriedade que referencia Covenant em Appointments se chama CovenantId

            //Table Configurations
            Property(a => a.Description)
                .HasMaxLength(Appointment.DescriptionMaxLength);

            Property(a => a.AppointmentType)
                .IsRequired();

            Property(a => a.AppointmentPrice)
                .IsRequired();

            //Property(a => a.DoctorId)
            //    .HasColumnName("DoctorId");

            //Property(a => a.PacientId)
            //    .HasColumnName("PacientId");

        }
    }
}