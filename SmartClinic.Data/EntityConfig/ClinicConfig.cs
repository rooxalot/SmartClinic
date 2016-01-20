using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class ClinicConfig : EntityTypeConfiguration<Clinic>
    {
        public ClinicConfig()
        {
            //Primary Key
            HasKey(c => c.Id);

            //Table Configuration
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(Clinic.NameMaxLength);

            Property(c => c.Header)
                .HasMaxLength(Clinic.HeaderMaxLength);
        }
    }
}