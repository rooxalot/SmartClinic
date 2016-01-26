using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using AutoMapper;
using SmartClinic.Application.ViewModels;
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

        public AppointmentViewModel CreateAppointment(AppointmentViewModel viewModel)
        {
            var appointment = Mapper.Map<Appointment>(viewModel);

            using (_unitOfWork)
            {
                _unitOfWork.AppoitmentRepository.Add(appointment);
                _unitOfWork.Commit();
            }

            return Mapper.Map<AppointmentViewModel>(appointment);
        }

        public void AlterAppointment(AppointmentViewModel viewModel)
        {
            Assertions.AssertArgumentNotNull(viewModel, "Não foi possível alterar a consulta. O parâmetro appointment não pode ser nulo");
            var appointment = Mapper.Map<Appointment>(viewModel);

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

        public void TransferAppointment(AppointmentViewModel appointmentViewModel, DoctorViewModel doctorViewModel)
        {
            var appointment = Mapper.Map<Appointment>(appointmentViewModel);
            var doctor = Mapper.Map<Doctor>(doctorViewModel);

            _appointmentService.TransferAppointment(appointment, doctor);
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctor(DoctorViewModel doctorViewModel)
        {
            var doctor = Mapper.Map<Doctor>(doctorViewModel);

            return _appointmentService.GetAppointmentsByDoctor(doctor);
        }

        public IEnumerable<AppointmentViewModel> GetPendingAppointments()
        {
            var appointments = _appointmentService.GetPendingAppointments();

            return Mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }



        #endregion
    }
}