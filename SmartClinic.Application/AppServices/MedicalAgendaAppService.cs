using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using System;

namespace SmartClinic.Application.AppServices
{
    public class MedicalAgendaAppService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentManager _appointmentManager;

        #endregion

        #region Constructor

        public MedicalAgendaAppService(IUnitOfWork unitOfWork, IAppointmentManager appointmentManager)
        {
            _unitOfWork = unitOfWork;
            _appointmentManager = appointmentManager;
        }

        #endregion

        #region Appservices

        public Appointment SetNewAppointment(Guid doctorID, Guid pacientID, Guid covenantID, DateTime appointmentDate, decimal? price, AppointmentType type, string description)
        {
            using (_unitOfWork)
            {
                var doctor = _unitOfWork.DoctorRepository.Get(doctorID);
                var pacient = _unitOfWork.PacientRepository.Get(pacientID);
                var covenant = _unitOfWork.CovenantRepository.Get(covenantID);
                var appointment = new Appointment(doctor, pacient, covenant, appointmentDate, price, type, description);

                appointment = _appointmentManager.SetAppointmentDoctor(appointment, doctor);
                appointment = _appointmentManager.SetAppointmentCovenant(appointment, covenant);

                _unitOfWork.AppoitmentRepository.Add(appointment);
                _unitOfWork.Commit();

                return appointment;
            }
        }

        #endregion

    }
}
