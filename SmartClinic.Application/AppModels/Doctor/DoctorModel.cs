using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Application.AppModels.Doctor
{
    public class DoctorModel
    {
        //doctor info
        public string Name { get; set; }
        public string Rg { get; set; }
        public bool Sex { get; set; }

        //doctor's crm info
        public long CrmCode { get; set; }
        public int CrmUf { get; set; }

        //doctor's address
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public int Uf { get; set; }

        //doctor's state
        public bool Active { get; set; }
    }
}
