using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class SecretaryConfig : EntityTypeConfiguration<Secretary>
    {
        public SecretaryConfig()
        {
            // Primary Key
            HasKey(s => s.Id);

            //Table Configuraton
            Property(s => s.Name)
                .HasMaxLength(Secretary.NameMaxLength);

            Property(s => s.Sex)
                .IsRequired();
        }
    }
}