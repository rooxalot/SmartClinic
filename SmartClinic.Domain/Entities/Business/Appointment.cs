using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.Enums;

namespace SmartClinic.Domain.Entities.Business
{
    public class Appointment : BaseEntity
    {

        #region Constructor

        // Constructor EntityFramework
        protected Appointment()
        {
        }

        public Appointment(Doctor doctor, Pacient pacient, Covenant covenant, DateTime appointmentDate, AppointmentType type)
        {
            SetDoctor(doctor);
            SetPacient(pacient);
            SetCovenant(covenant);
            SetAppointmentDate(appointmentDate);
            AppointmentType = type;
        }

        public Appointment(Doctor doctor, Pacient pacient, Covenant covenant, DateTime appointmentDate, decimal? price, 
            AppointmentType type, string description = null)
        {
            SetDoctor(doctor);
            SetPacient(pacient);
            SetCovenant(covenant);
            SetAppointmentDate(appointmentDate);
            SetAppointmentPrice(price);
            AppointmentType = type;

            if(!string.IsNullOrEmpty(description))
                SetDescription(description);
        }

        #endregion

        #region Constants

        public const int DescriptionMaxLength = 200;

        #endregion

        #region Properties

        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public decimal? AppointmentPrice { get; private set; }
        public AppointmentType AppointmentType { get; set; }
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; }
        public Guid PacientId { get; private set; }
        public virtual Pacient Pacient { get; private set; }
        public Guid ConvenantId { get; private set; }
        public virtual Covenant Covenant { get; private set; }

        #endregion

        #region Methods

        public void SetDescription(string description)
        {
            if(description.Length > DescriptionMaxLength)
                throw new InvalidOperationException(string.Format("A descrição deve possuir no máximo {0} caracteres", DescriptionMaxLength));

            Description = description;
        }

        public void SetDoctor(Doctor doctor)
        {
            if(doctor == null)
                throw new InvalidOperationException("Não é possível associar o médico a consulta. Médico está nulo");

            Doctor = doctor;
        }

        public void SetPacient(Pacient pacient)
        {
            if(pacient == null)
                throw new ArgumentNullException("pacient");

            Pacient = pacient;
        }

        public void SetCovenant(Covenant covenant)
        {
            if(covenant == null)
                throw new InvalidOperationException("Não é possível associar o convenio a consulta. Convenio está nulo");

            Covenant = covenant;
        }

        public void SetAppointmentPrice(decimal? price)
        {
            if (price < 0)
                throw new InvalidOperationException("Não é possível associar um valor negativo ao preço da consulta");

            AppointmentPrice = price ?? 0;
        }

        public void SetAppointmentDate(DateTime date)
        {
            if (date.Date < DateTime.Now.Date)
                throw new InvalidOperationException("A data da consulta não pode possuír a data retroativa");

            Date = date;
        }

        public bool IsPending()
        {
            return Date > DateTime.Now;
        }

        #endregion
    }
}