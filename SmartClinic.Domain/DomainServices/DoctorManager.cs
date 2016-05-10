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

        /// <summary>
        /// Realiza as validações para definir se o CRM do médico
        /// </summary>
        /// <param name="doctor">Entidade que irá receber o CRM</param>
        /// <param name="crm">Objeto CRM que será atribuido ao médico</param>
        /// <returns>Entidade com seu CRM atualizado</returns>
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

        /// <summary>
        /// Realiza as validações para a desativação do médico no sistema
        /// </summary>
        /// <param name="doctor">Entidade a ser desativada</param>
        /// <returns>Entidade com seu status já desativado</returns>
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