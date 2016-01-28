using SmartClinic.Domain.Entities.Business;
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
            using (_unitOfWork)
            {
                //Obtem o paciente da consulta
                var pacient = _unitOfWork.PacientRepository.Get(viewModel.PacientId);

                //Obtem o médico da consulta
                var doctor = _unitOfWork.DoctorRepository.Get(viewModel.DoctorId);

                //Obtem o convêncio da consulta
                var covenant = _unitOfWork.CovenantRepository.Get(viewModel.ConvenantId);

                //Obtem a consulta a partir do DTO
                var appointment = Mapper.Map<AppointmentViewModel, Appointment>(viewModel,
                    new Appointment(doctor, pacient, covenant, viewModel.Date, viewModel.AppointmentPrice,
                        viewModel.AppointmentType, viewModel.Description));

                _unitOfWork.AppoitmentRepository.Add(appointment);
                _unitOfWork.Commit();
            }

            return viewModel;
        }

        public void AlterAppointment(AppointmentViewModel viewModel)
        {
            Assertions.AssertArgumentNotNull(viewModel, "Não foi possível alterar a consulta. O parâmetro appointment não pode ser nulo");

            using (_unitOfWork)
            {
                //Obtem o paciente da consulta
                var pacient = _unitOfWork.PacientRepository.Get(viewModel.PacientId);

                //Obtem o médico da consulta
                var doctor = _unitOfWork.DoctorRepository.Get(viewModel.DoctorId);

                //Obtem o convêncio da consulta
                var covenant = _unitOfWork.CovenantRepository.Get(viewModel.ConvenantId);

                //Obtem a consulta a partir do DTO
                var appointment = Mapper.Map<AppointmentViewModel, Appointment>(viewModel,
                    new Appointment(doctor, pacient, covenant, viewModel.Date, viewModel.AppointmentPrice,
                        viewModel.AppointmentType, viewModel.Description));

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
            //Obtem o paciente da consulta
            var pacient = _unitOfWork.PacientRepository.Get(appointmentViewModel.PacientId);

            //Obtem o médico da consulta
            var doctor = _unitOfWork.DoctorRepository.Get(appointmentViewModel.DoctorId);

            //Obtem o convêncio da consulta
            var covenant = _unitOfWork.CovenantRepository.Get(appointmentViewModel.ConvenantId);

            //Obtem a consulta a partir do DTO
            var appointmentEntity = Mapper.Map<AppointmentViewModel, Appointment>(appointmentViewModel,
                new Appointment(doctor, pacient, covenant, appointmentViewModel.Date, appointmentViewModel.AppointmentPrice,
                    appointmentViewModel.AppointmentType, appointmentViewModel.Description));

            //Obtem o médico a partir do DTO
            var doctorEntity = Mapper.Map<DoctorViewModel, Doctor>(doctorViewModel,
                new Doctor(doctorViewModel.Name, doctorViewModel.Rg, doctorViewModel.Crm, doctorViewModel.Active, doctorViewModel.Sex,
                    doctorViewModel.Address));

            _appointmentService.TransferAppointment(appointmentEntity, doctorEntity);
        }

        public IEnumerable<AppointmentViewModel> GetAppointmentsByDoctor(DoctorViewModel doctorViewModel)
        {
            //Obtem o médico a partir do DTO
            var doctor = Mapper.Map<DoctorViewModel, Doctor>(doctorViewModel,
                new Doctor(doctorViewModel.Name, doctorViewModel.Rg, doctorViewModel.Crm, doctorViewModel.Active, doctorViewModel.Sex,
                    doctorViewModel.Address));

            var appointments = _appointmentService.GetAppointmentsByDoctor(doctor);

            return Mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }

        public IEnumerable<AppointmentViewModel> GetPendingAppointments()
        {
            var appointments = _appointmentService.GetPendingAppointments();

            return Mapper.Map<IEnumerable<AppointmentViewModel>>(appointments);
        }



        #endregion
    }
}