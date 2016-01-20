using SmartClinic.Data.Context;

namespace SmartClinic.Infrastructure.CrossCutting.ContextConfig
{
    public static class ContextInit
    {
        public static void Init()
        {
            var context = new SmartClinicContext();
            context.Dispose();
        }
    }
}