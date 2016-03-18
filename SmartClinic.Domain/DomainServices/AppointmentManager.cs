using System;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Domain.DomainServices
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment SetAppointmentCovenant(Appointment appointment, Covenant covenant)
        {
            if (!covenant.IsActive())
                throw new InvalidOperationException("Deve ser associado um convenio ativo a consulta");

            if(!appointment.Pacient.Covenant.Equals(covenant))
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
    }
}