using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels.DoctorModels
{
    public class RegisterDoctorViewModel
    {
        [Required]
        [StringLength(Doctor.NameMaxLength, ErrorMessage = "A quantidade de caracteres para o campo Nome foi ultrapassada")]
        public string Name { get; set; }

        [StringLength(Domain.ValueObjects.Rg.RgMaxLength, MinimumLength = Domain.ValueObjects.Rg.RgMinLength,
            ErrorMessage = "A quantidade de caracteres para o RG está invalida")]
        [Required(AllowEmptyStrings = true)]
        public string Rg { get; set; }

        [Required]
        [StringLength(Crm.CrmMaxLength, ErrorMessage = "A quantidade de caracteres para para o CRM foi ultrapassado")]
        public string CrmCode { get; set; }

        [Required]
        public Uf CrmUf { get; set; }

        public Address Address { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public Sex Sex { get; set; }
    }
}