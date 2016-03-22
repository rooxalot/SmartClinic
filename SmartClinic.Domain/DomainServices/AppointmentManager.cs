using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.DomainServices
{
    public class AppointmentManager : IAppointmentManager
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public AppointmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Services

        public IEnumerable<Appointment> GetPendingAppointments(int days = 0)
        {
            if (days < 0)
                throw new Exception("Filtro de dias para consultas não pode ser menor que 0");

            IEnumerable<Appointment> appointments = null;
            if (days > 0)
                appointments = _unitOfWork
                    .AppoitmentRepository
                    .Find(a => a.IsPending() && a.Date <= DateTime.Now.AddDays(days));
            else
                appointments = appointments = _unitOfWork
                    .AppoitmentRepository
                    .Find(a => a.IsPending().Equals(true));

            return appointments;
        }

        public Appointment SetAppointmentCovenant(Appointment appointment, Covenant covenant)
        {
            if (!covenant.IsActive())
                throw new InvalidOperationException("Deve ser associado um convenio ativo a consulta");

            if (!appointment.Pacient.Covenant.Equals(covenant))
                throw new InvalidOperationException("O convenio associado a consulta não é o mesmo do paciente");

            appointment.SetCovenant(covenant);
            return appointment;
        }

        public Appointment SetAppointmentDoctor(Appointment appointment, Doctor doctor)
        {
            if (!doctor.Active)
                throw new InvalidOperationException("O médico associado a consulta não está ativo");

            appointment.SetDoctor(doctor);
            return appointment;
        }

        public Appointment SetAppointmentCancelation(Appointment appointment, bool isCanceled)
        {
            //Descancelamento da consulta
            if (!isCanceled)
            {
                var doctor = _unitOfWork.DoctorRepository.Get(appointment.DoctorId);
                if (doctor == null)
                {
                    appointment.SetCanceled(true);
                    throw new Exception("O médico da consulta está nulo, para que seja possível descancelar a consulta, associe um médico valido a mesma");
                }
                else
                {
                    if (!doctor.Active)
                    {
                        appointment.SetCanceled(true);
                        throw new Exception("O médico da consulta está inativo, para que seja possível descancelar a consulta, associe um médico valido a mesma");
                    }
                }
            }
            //Cancelamento da consulta
            else
                appointment.SetCanceled(true);

            return appointment;
        }

        #endregion
    }
}