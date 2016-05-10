
using System;
using System.Collections.Generic;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Entities.Business
{
    public class Doctor : BaseEntity
    {
        #region Constants

        public const int NameMaxLength = 150;
        public const int NameMinLength = 3;

        #endregion

        #region Constructor

        //Construtor EntityFramework
        protected Doctor()
        {
        }

        public Doctor(string name, Rg rg, Crm crm, bool active, Sex sex, Address address)
        {
            SetName(name);
            SetRg(rg);
            SetCrm(crm);
            Active = active;
            Sex = sex;
            SetAdress(address);
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Rg Rg { get; set; }
        public Crm Crm { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; private set; }
        public Sex Sex { get; set; }
        public IEnumerable<Appointment> Appointments { get; private set; }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Nome do Médico não pode ser nulo ou vazio");

            if(name.Length > NameMaxLength || name.Length < NameMinLength)
                throw new InvalidOperationException(string.Format("O Nome do médico deve possuir entre {0} a {1} caratctes", NameMinLength, NameMaxLength));

            Name = name;
        }

        public void SetCrm(Crm crm)
        {
            if(crm == null)
                throw new ArgumentNullException("crm");

            Crm = crm;
        }

        public void SetAdress(Address address)
        {
            if (address == null)
                Address = new Address();

            Address = address;
        }

        public void SetActive(bool isActive)
        {
            Active = isActive;
        }

        public void SetRg(Rg rg)
        {
            if (rg == null)
                Rg = new Rg();

            Rg = rg;
        }

        #endregion
    }
}