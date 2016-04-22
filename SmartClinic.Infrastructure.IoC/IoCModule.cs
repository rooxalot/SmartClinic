using Ninject.Modules;
using SmartClinic.Application.AppServices;
using SmartClinic.Data.Context;
using SmartClinic.Data.Repositories.Base;
using SmartClinic.Data.Repositories.Business;
using SmartClinic.Data.UnitOfWork;
using SmartClinic.Domain.DomainServices;
using SmartClinic.Domain.Interfaces.CrossCutting;
using SmartClinic.Domain.Interfaces.DomainServices;
using SmartClinic.Domain.Interfaces.Repositories.Base;
using SmartClinic.Domain.Interfaces.Repositories.Business;
using SmartClinic.Domain.Interfaces.UnitOfWork;
using SmartClinic.Infrastructure.CrossCutting.Security;
using System.Data.Entity;

namespace SmartClinic.Infrastructure.IoC
{
    public class IoCModule : NinjectModule
    {
        public override void Load()
        {
            //Contexts
            Bind<DbContext>().To<DbContext>();
            Bind<SmartClinicContext>().To<SmartClinicContext>();

            //CrossCutting
            Bind<IEncrypter>().To<Encrypter>();

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

            //UnitOfWork
            Bind<IUnitOfWork>().To<UnitOfWork>();

            //DomainServices
            Bind<IAppointmentManager>().To<AppointmentManager>();
            Bind<IDoctorManager>().To<DoctorManager>();
            Bind<IPacientManager>().To<PacientManager>();
            Bind<IUserManager>().To<UserManager>();

            //AppServices
            Bind<ClinicAppService>().To<ClinicAppService>();
            Bind<CovenantAppService>().To<CovenantAppService>();
            Bind<DoctorAppService>().To<DoctorAppService>();
            Bind<MedicalAgendaAppService>().To<MedicalAgendaAppService>();
            Bind<PacientAppService>().To<PacientAppService>();
            Bind<SecretaryAppService>().To<SecretaryAppService>();
            Bind<UserAppService>().To<UserAppService>();
        }
    }
}