using System;
using System.Collections.Generic;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.MVC.ViewModels
{
    public class DoctorViewModel
    {

        #region Properties

        public string Name { get; private set; }
        public Rg Rg { get; set; }
        public Crm Crm { get; private set; }
        public Address Address { get; private set; }
        public Sex Sex { get; set; }
        public IEnumerable<AppointmentViewModel> Appointments { get; private set; }

        #endregion
    }
}