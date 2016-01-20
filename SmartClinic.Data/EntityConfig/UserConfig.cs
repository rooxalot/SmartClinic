using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.InteropServices;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Data.EntityConfig
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            //Primary Key
            HasKey(u => u.Id);

            Property(u => u.Login)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(new IndexAttribute("IXUserLogin_Unique") {IsUnique = true}));
        }
    }
}