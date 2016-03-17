using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels.DoctorModels
{
    public class RegisterDoctorViewModel
    {

        public Guid Id { get; set; }

        [Required]
        [StringLength(Doctor.NameMaxLength, ErrorMessage = "A quantidade de caracteres para o campo Nomde foi ultrapassada")]
        public string Name { get; set; }


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