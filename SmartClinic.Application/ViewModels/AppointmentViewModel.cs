using System;
using SmartClinic.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Entities.Business;

namespace SmartClinic.Application.ViewModels
{
    public class AppointmentViewModel
    {

        #region Properties

        [StringLength(Appointment.DescriptionMaxLength, ErrorMessage = "A descrição da consulta possuí mais caracteres que o permitido")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Data da consulta é obrigatória")]
        public DateTime Date { get; set; }

        [Range(0.0d, double.MaxValue, ErrorMessage = "O preço da consulta não é valido")]
        public decimal AppointmentPrice { get; set; }

        public AppointmentType AppointmentType { get; set; }

        public Guid DoctorId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o médico da consulta")]
        public virtual DoctorViewModel Doctor { get; set; }

        public Guid PacientId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o paciente da consulta")]
        public virtual PacientViewModel Pacient { get; set; }

        public Guid ConvenantId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o convenio atribuído a consulta")]
        public virtual CovenantViewModel Covenant { get; set; }

        #endregion
    }
}