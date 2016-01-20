using System;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Application.ViewModels
{
    public class PacientViewModel
    {
        #region Properties

        public string Name { get; private set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public Rg Rg { get; set; }
        public Sex Sex { get; private set; }
        public Guid ConvenantId { get; private set; }
        public virtual CovenantViewModel Covenant { get; private set; }

        #endregion
    }
}