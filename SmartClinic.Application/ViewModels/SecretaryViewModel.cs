using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;
using System;

namespace SmartClinic.Application.ViewModels
{
    public class SecretaryViewModel
    {

        #region Properties

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Secretary.NameMaxLength, ErrorMessage = "A quantidade de caracteres no campo Nome é invalida")]
        public string Name { get; set; }

        public Rg Rg { get; set; }

        public Phone Phone { get; set; }

        public Address Address { get; set; }

        [Required]
        public Sex Sex { get; set; }

        #endregion
    }
}