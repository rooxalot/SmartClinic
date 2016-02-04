using SmartClinic.Domain.Enums;

namespace SmartClinic.Application.ViewModels.AddressViewModels
{
    public class AddressViewModel
    {
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }
    }
}