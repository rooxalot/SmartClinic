using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class PacientConfig : EntityTypeConfiguration<Pacient>
    {
        public PacientConfig()
        {
            //Primary Key
            HasKey(p => p.Id);

            //Foreign Key
            HasRequired(p => p.Covenant) // A propriedade Covenant de Pacient é obrigatória
                .WithMany() // Um covenant pode ter vários Pacients
                .HasForeignKey(p => p.ConvenantId); // A Foreign Key que associa o Pacient a um Convenant é ConvenantId

            //Table Configuration
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(Pacient.NameMaxLength);

            Property(p => p.Sex)
                .IsRequired();
        }
    }
}