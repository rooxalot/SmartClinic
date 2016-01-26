using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels
{
    public class CovenantViewModel
    {

        #region Properties
        [StringLength(Covenant.NameMaxLength, MinimumLength = Covenant.NameMinLength, ErrorMessage = "A quantidade de caracteres no campo Nome não é valida")]
        public string Name { get; set; }

        public Phone Phone { get; set; }

        public Cnpj Cnpj { get; set; }

        public bool Active { get; set; }

        [Required]
        public DateTime StartTerm { get; set; }

        [Required]
        public DateTime EndTerm { get; set; }

        [Required]
        [StringLength(Covenant.OfferedPlansMaxLength, ErrorMessage = "A quantidade de caracteres no campo Planos Oferecidos não é valida")]
        public string OfferedPlans { get; set; }

        #endregion

    }
}