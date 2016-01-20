using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Validations;

namespace SmartClinic.Application.AppServices
{
    public class AppointmentAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentService _appointmentService;

        #endregion

        #region Constructor

        public AppointmentAppService(IUnitOfWork unitOfWork, IAppointmentService appointmentService)
        {
            _unitOfWork = unitOfWork;
            _appointmentService = appointmentService;
        }

        #endregion

        #region Services

        public Appointment CreateAppointmentWithoutPrice(Doctor doctor, Pacient pacient, Covenant covenant, DateTime appointmentDate,
            AppointmentType type)
        {
            var appointment = CreateAppointmentWithPrice(doctor, pacient, covenant, appointmentDate, 0M, type);

            return appointment;
        }

        public Appointment CreateAppointmentWithPrice(Doctor doctor, Pacient pacient, Covenant covenant, DateTime appointmentDate,
            decimal price, AppointmentType type)
        {
            var appointment = new Appointment(doctor, pacient, covenant, appointmentDate, price, type);

            using (_unitOfWork)
            {
                _unitOfWork.AppoitmentRepository.Add(appointment);
                _unitOfWork.Commit();
            }

            return appointment;
        }

        public void AlterAppointment(Appointment appointment)
        {
            Assertions.AssertArgumentNotNull(appointment, "Não foi possível alterar a consulta. O parâmetro appointment não pode ser nulo");

            using (_unitOfWork)
            {
                _unitOfWork.AppoitmentRepository.Update(appointment);
                _unitOfWork.Commit();
            }
        }

        public void RemoveAppointment(Guid id)
        {
            using (_unitOfWork)
            {
                var appointment = _unitOfWork.AppoitmentRepository.Get(id);
                Assertions.AssertArgumentNotNull(appointment, "Não foi possível remover a consulta. Não foi encontrada nenhuma consulta com o ID");

                _unitOfWork.AppoitmentRepository.Remove(appointment);
                _unitOfWork.Commit();
            }
        }

        public void TransferAppointment(Appointment appointment, Doctor doctor)
        {
            _appointmentService.TransferAppointment(appointment, doctor);
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
        {
            return _appointmentService.GetAppointmentsByDoctor(doctor);
        }

        public IEnumerable<Appointment> GetPendingAppointments()
        {
            return _appointmentService.GetPendingAppointments();
        }

        #endregion
    }
}