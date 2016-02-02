using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;
using System;

namespace SmartClinic.Application.ViewModels
{
    public class DoctorViewModel
    {

        #region Properties

        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(Doctor.NameMaxLength, ErrorMessage = "A quantidade de caracteres no campo Nome não é valida")]
        public string Name { get; set; }

        public Rg Rg { get; set; }

        [Required]
        public Crm Crm { get; set; }

        public bool Active { get; set; }

        public Address Address { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }

        #endregion
    }
}