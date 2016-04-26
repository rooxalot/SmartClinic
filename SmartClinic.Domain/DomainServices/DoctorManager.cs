using System;
using System.Linq;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.ValueObjects;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Domain.DomainServices
{
    public class DoctorManager : IDoctorManager
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentManager _appointmentManager;

        #endregion

        #region Constructor

        public DoctorManager(IUnitOfWork unitOfWork, IAppointmentManager appointmentManager)
        {
            _unitOfWork = unitOfWork;
            _appointmentManager = appointmentManager;
        }

        #endregion

        #region Services

        public Doctor SetDoctorCrm(Doctor doctor, Crm crm)
        {
            var crmExists = _unitOfWork
                .DoctorRepository
                .Find(d => d.Crm.Code.Equals(crm.Code) && d.Crm.Uf.Equals(crm.Uf) && d.Id != doctor.Id)
                .Any();

            if (crmExists)
                throw new Exception("CRM já existe, não foi possível realizar a associação ao médico.");

            doctor.SetCrm(crm);
            return doctor;
        }

        public Doctor DeactivateDoctor(Doctor doctor)
        {
            var doctorAppointments = _unitOfWork.AppoitmentRepository.GetAppointmentsByDoctor(doctor).ToList();

            if (doctorAppointments.Any())
            {
                foreach (var appointment in doctorAppointments)
                    _appointmentManager.SetAppointmentCancelation(appointment, true);
            }

            doctor.SetActive(false);
            return doctor;
        }

        #endregion
    }
}