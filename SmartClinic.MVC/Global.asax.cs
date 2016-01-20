using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SmartClinic.Infrastructure.CrossCutting.ContextInit;
using SmartClinic.Application.AutoMapper;

namespace SmartClinic.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
            ContextInit.Init();

            //var ioc = IoC.GetKernel();

            ////Add user
            //new UserAppService(ioc.Get<IUnitOfWork>()).RegisterUser("admin", "power123", true, UserType.Administrator);


            ////Add Clinic
            //new ClinicAppService(ioc.Get<IUnitOfWork>()).RegisterClinic("SmartClinicDefault", "Cuidando de você", 
            //    new Cnpj(59899760000165), new Phone(59318988, 11));
            

            ////Add Secretaries
            //new SecretaryAppService(ioc.Get<IUnitOfWork>()).RegisterSecretary("Anna Rosa", new Rg(0987890675), new Phone(29894434),
            //    new Address("Rua Padre Gabriel Campos", "Próx. ao Octacilio", "292", "Arthur Alvim", "São Paulo", Uf.SP),
            //    Sex.Feminino);


            ////Add Doctor
            //new DoctorAppService(ioc.Get<IUnitOfWork>(), ioc.Get<IDoctorService>())
            //    .RegisterDoctor("Carlos Luiz", new Rg(0989098975), new Crm("8904756457", Uf.SP), Sex.Masculino,
            //    new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP));

            //new DoctorAppService(ioc.Get<IUnitOfWork>(), ioc.Get<IDoctorService>())
            //    .RegisterDoctor("Sandra", new Rg(5678916530), new Crm("8904067454", Uf.SP), Sex.Feminino,
            //    new Address("Av Pablo Luiz", "Próximo ao Extra", "4566", "Arthur Alvim", "Rio de Janeiro", Uf.RJ));

            
            ////Add Covenant
            //new CovenantAppService(ioc.Get<IUnitOfWork>(), ioc.Get<ICovenantService>())
            //    .RegisterCovenantWithOfferedPlans("Sancil", true, DateTime.Now, DateTime.Now.AddYears(2),
            //        new Phone(89518988, 11), new Cnpj(59899760580165), "Consultas a domicilio e plano odontológico.");

            //new CovenantAppService(ioc.Get<IUnitOfWork>(), ioc.Get<ICovenantService>())
            //    .RegisterCovenantWithoutOfferedPlans("UltraMed", true, DateTime.Now, 
            //        DateTime.Now.AddYears(1), new Phone(), new Cnpj(59896980580160));

            //new CovenantAppService(ioc.Get<IUnitOfWork>(), ioc.Get<ICovenantService>())
            //    .RegisterCovenantWithoutOfferedPlans("Amil", true, DateTime.Now, DateTime.Now.AddYears(1), new Phone(),
            //    new Cnpj(57796980580163));
            

            ////Add Pacient
            //new PacientAppService(ioc.Get<IUnitOfWork>(), ioc.Get<IPacientService>())
            //    .RegisterPacient("Rodrigo Martins", 
            //        new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP),
            //        new Phone(), new Rg(), Sex.Masculino, new CovenantAppService(ioc.Get<IUnitOfWork>(), ioc.Get<ICovenantService>())
            //            .GetAllActiveCovenants().FirstOrDefault());

            //new PacientAppService(ioc.Get<IUnitOfWork>(), ioc.Get<IPacientService>())
            //    .RegisterPacient("Maria Inez",
            //    new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP),
            //    new Phone(), new Rg(), Sex.Masculino, new CovenantAppService(ioc.Get<IUnitOfWork>(), ioc.Get<ICovenantService>())
            //        .GetAllActiveCovenants().ToArray()[1]);
        }
    }
}