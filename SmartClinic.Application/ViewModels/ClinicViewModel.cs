using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels
{
    public class ClinicViewModel
    {

        #region Properties

        public string Name { get; private set; }
        public string Header { get; private set; }
        public Cnpj Cnpj { get; set; }
        public Phone Phone { get; set; }

        #endregion

    }
}