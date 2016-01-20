using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.BusinessServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
        {
            if(doctor == null)
                throw new InvalidOperationException("Não é possível obter as consultas. O médico informado não pode ser nulo");

            using (_unitOfWork)
            {
                return _unitOfWork.AppoitmentRepository.GetAppointmentsByDoctor(doctor);
            }
        }


        public IEnumerable<Appointment> GetLastSevenDaysAppointments()
        {
            using (_unitOfWork)
            {
                return _unitOfWork.AppoitmentRepository
                    .GetAppointmentsWithinDateRange(DateTime.Now.AddDays(-7), DateTime.Now);
            }
        }


        public IEnumerable<Appointment> GetTodayAppointments()
        {
            using (_unitOfWork)
            {
                return _unitOfWork.AppoitmentRepository
                    .GetAppointmentsWithinDateRange(DateTime.Now, DateTime.Now);
            }
        }


        public IEnumerable<Appointment> GetPendingAppointments()
        {
            using (_unitOfWork)
            {
                return _unitOfWork.AppoitmentRepository.GetPendingAppointments();
            }
        }


        public void TransferAppointment(Appointment appointment, Doctor doctor)
        {
            if(appointment == null)
                throw new InvalidOperationException("Não é possível transferir a consulta. A consulta não pode ser nula");

            if(doctor == null)
                throw new InvalidOperationException("Não é possível transferir a consulta. O médico informado não pode ser nula");

            using (_unitOfWork)
            {
                appointment.SetDoctor(doctor);

                _unitOfWork.AppoitmentRepository.Update(appointment);
                _unitOfWork.Commit();
            }
        }
    }
}