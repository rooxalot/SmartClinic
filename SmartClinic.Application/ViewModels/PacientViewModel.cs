using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels
{
    public class PacientViewModel
    {
        #region Properties

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Pacient.NameMaxLength, ErrorMessage = "A quantidade de caracteres no campo Nome é invalida")]
        public string Name { get; set; }

        public Address Address { get; set; }

        public Phone Phone { get; set; }

        public Rg Rg { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [ScaffoldColumn(false)]
        public Guid ConvenantId { get; set; }

        [ScaffoldColumn(false)]
        public virtual CovenantViewModel Covenant { get; set; }

        #endregion
    }
}