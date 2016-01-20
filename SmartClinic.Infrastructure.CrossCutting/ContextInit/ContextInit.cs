using SmartClinic.Data.Context;

namespace SmartClinic.Infrastructure.CrossCutting.ContextInit
{
    public class ContextInit
    {
        public static void Init()
        {
            new SmartClinicContext().Dispose();
        }
    }
}