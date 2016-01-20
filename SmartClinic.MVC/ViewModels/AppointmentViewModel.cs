using System;
using System.ComponentModel.DataAnnotations;
using SmartClinic.Domain.Enums;

namespace SmartClinic.MVC.ViewModels
{
    public class AppointmentViewModel
    {
        #region Properties

        public string Description { get; private set; }


        [Required(ErrorMessage = "Data da consulta é obrigatória")]
        public DateTime Date { get; private set; }


        public decimal AppointmentPrice { get; private set; }

        public AppointmentType AppointmentType { get; set; }

        public Guid DoctorId { get; private set; }
        [Required(ErrorMessage = "É obrigatório informar o médico da consulta")]
        public virtual DoctorViewModel Doctor { get; private set; }

        public Guid PacientId { get; private set; }

        [Required(ErrorMessage = "É obrigatório informar o paciente da consulta")]
        public virtual PacientViewModel Pacient { get; private set; }

        public Guid ConvenantId { get; private set; }

        [Required(ErrorMessage = "É obrigatório informar o convenio atribuído a consulta")]
        public virtual CovenantViewModel Covenant { get; private set; }

        #endregion
    }
}