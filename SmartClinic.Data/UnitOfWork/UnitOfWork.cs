using System;
using System.Data.Entity;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Business;
using SmartClinic.Domain.Interfaces.Repositories.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;

namespace SmartClinic.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructor

        public UnitOfWork(SmartClinicContext context)
        {
            _context = context;

            AppoitmentRepository = new AppoitmentRepository(context);
            ClinicRepository = new ClinicRepository(context);
            CovenantRepository = new CovenantRepository(context);
            DoctorRepository = new DoctorRepository(context);
            MedicalRecordRepository = new MedicalRecordRepository(context);
            PacientRepository = new PacientRepository(context);
            SecretaryRepository = new SecretaryRepository(context);
            UserRepository = new UserRepository(context);
        }

        #endregion

        #region Properties

        private readonly SmartClinicContext _context;
        private bool _isDisposed;

        public IAppointmentRepository AppoitmentRepository { get; }
        public IClinicRepository ClinicRepository { get; }
        public ICovenantRepository CovenantRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IMedicalRecordRepository MedicalRecordRepository { get; }
        public IPacientRepository PacientRepository { get; }
        public ISecretaryRepository SecretaryRepository { get; }
        public IUserRepository UserRepository { get; }

        #endregion

        #region Methods

        public void Commit()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(GetType().Name);

            _context.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Unchanged;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _isDisposed = true;
        }

        #endregion
    }
}