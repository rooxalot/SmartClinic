using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.MVC.ViewModels
{
    public class SecretaryViewModel
    {

        #region Properties

        public string Name { get; private set; }
        public Rg Rg { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public Sex Sex { get; private set; }

        #endregion
    }
}