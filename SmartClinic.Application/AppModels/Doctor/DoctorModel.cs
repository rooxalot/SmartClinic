using SmartClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.AppModels.Doctor
{
    public class DoctorModel
    {
        //doctor info
        public Guid Id { get; set; }

        [Required]
        [StringLength(Domain.Entities.Business.Doctor.NameMaxLength, MinimumLength = Domain.Entities.Business.Doctor.NameMinLength, 
            ErrorMessage = "O campo nome possui um número incorreto de caracteres")]
        public string Name { get; set; }

        [StringLength(Domain.ValueObjects.Rg.RgMaxLength, MinimumLength = Domain.ValueObjects.Rg.RgMinLength,
            ErrorMessage = "O campo Rg possui um número incorreto de caracteres")]
        public string RgCode { get; set; }

        
        public Sex Sex { get; set; }

        //doctor's crm info
        [StringLength(Domain.ValueObjects.Crm.CrmMaxLength, ErrorMessage = "O CRM possui um número incorreto de digitos")]
        public string CrmCode { get; set; }

        public Uf CrmUf { get; set; }

        //doctor's address
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }

        //doctor's state
        public bool Active { get; set; }
    }
}
