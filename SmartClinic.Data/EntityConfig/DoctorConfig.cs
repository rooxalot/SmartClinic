using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class DoctorConfig : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfig()
        {
            //Primary Key
            HasKey(p => p.Id);

            //Table Configurations
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(Doctor.NameMaxLength);

            Property(p => p.Crm.Code)
                .IsRequired()
                .HasColumnName("CrmCode")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(
                        new IndexAttribute("IX_DoctorCrm_Unique", 1) { IsUnique = true }));

            Property(p => p.Crm.Uf)
                .IsRequired()
                .HasColumnName("CrmUf")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_DoctorCrm_Unique", 2) { IsUnique = true }));

            Property(p => p.Sex)
                .IsRequired();
        }
    }
}