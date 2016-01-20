using System;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.MVC.ViewModels
{
    public class CovenantViewModel
    {

        #region Properties

        public string Name { get; private set; }
        public Phone Phone { get; set; }
        public Cnpj Cnpj { get; set; }
        public bool Active { get; set; }
        public DateTime StartTerm { get; private set; }
        public DateTime EndTerm { get; private set; }
        public string OfferedPlans { get; private set; }

        #endregion

    }
}