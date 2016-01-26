using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels
{
    public class ClinicViewModel
    {

        #region Properties

        [Required]
        [StringLength(Clinic.NameMaxLength, MinimumLength = Clinic.NameMinLength, ErrorMessage = "A quantidade de caracteres no campo Nome não é valida")]
        public string Name { get; set; }

        [StringLength(Clinic.HeaderMaxLength, ErrorMessage = "A quantidade de caracteres no campo Cabeçalho não é valida")]
        public string Header { get; set; }

        public Cnpj Cnpj { get; set; }

        public Phone Phone { get; set; }

        #endregion

    }
}