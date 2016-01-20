using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class CovenantConfig : EntityTypeConfiguration<Covenant>
    {
        public CovenantConfig()
        {
            //Primary Key
            HasKey(c => c.Id);

            //Table Configuraton
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(Covenant.NameMaxLength);

            Property(c => c.OfferedPlans)
                .HasMaxLength(Covenant.OfferedPlansMaxLength);
        }
    }
}