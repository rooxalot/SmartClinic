using Ninject.Modules;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Data.Repositories.Business;
using SmartClinic.Data.UnitOfWork;
using SmartClinic.Domain.Interfaces.Repositories.Base;
using SmartClinic.Domain.Interfaces.Repositories.Business;
using SmartClinic.Domain.Interfaces.BusinessServices;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Domain.BusinessServices;
using System.Data.Entity;
using Ninject;
using SmartClinic.Data.Context;

namespace SmartClinic.Infrastructure.IoC
{
    public class IoCModule : NinjectModule
    {
        public override void Load()
        {
            //UnitOfWork
            Bind<IUnitOfWork>().To<UnitOfWork>();

            //Contexts
            Bind<DbContext>().To<DbContext>();
            Bind<SmartClinicContext>().To<SmartClinicContext>();

            //Repositories
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            Bind<IAppointmentRepository>().To<AppoitmentRepository>();
            Bind<IClinicRepository>().To<ClinicRepository>();
            Bind<ICovenantRepository>().To<CovenantRepository>();
            Bind<IDoctorRepository>().To<DoctorRepository>();
            Bind<IMedicalRecordRepository>().To<MedicalRecordRepository>();
            Bind<IPacientRepository>().To<PacientRepository>();
            Bind<ISecretaryRepository>().To<SecretaryRepository>();
            Bind<IUserRepository>().To<UserRepository>();

            //Services
            Bind<IAppointmentService>().To<AppointmentService>();
            Bind<IClinicService>().To<ClinicService>();
            Bind<ICovenantService>().To<CovenantService>();
            Bind<IDoctorService>().To<DoctorService>();
            Bind<IMedicalRecordService>().To<MedicalRecordService>();
            Bind<IPacientService>().To<PacientService>();
            Bind<ISecretaryService>().To<SecretaryService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}