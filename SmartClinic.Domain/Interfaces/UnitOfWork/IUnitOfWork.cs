using System;
using SmartClinic.Domain.Interfaces.Repositories.Business;

namespace SmartClinic.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository AppoitmentRepository { get; }
        IClinicRepository ClinicRepository { get; }
        ICovenantRepository CovenantRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IMedicalRecordRepository MedicalRecordRepository { get; }
        IPacientRepository PacientRepository { get; }
        ISecretaryRepository SecretaryRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
        void Rollback();
    }
}