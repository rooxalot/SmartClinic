using Ninject;

namespace SmartClinic.Infrastructure.IoC
{
    public class IoC
    {
        public static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load<IoCModule>();

            return kernel;
        }
    }
}