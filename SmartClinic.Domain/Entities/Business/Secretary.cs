using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Entities.Business
{
    public class Secretary : BaseEntity
    {
        #region Constructor

        //Construtor EntityFramework
        protected Secretary()
        {
        }

        public Secretary(string name, Rg rg, Phone phone, Address address, Sex sex)
        {
            SetRg(rg);
            SetPhone(phone);
            SetAddress(address);
            SetName(name);
            Sex = sex;
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Rg Rg { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public Sex Sex { get; private set; }

        #endregion

        #region Constants

        public const int NameMaxLength = 180;

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Nome não pode ser nulo ou vazio");
            
            if(name.Length > NameMaxLength)
                throw new InvalidOperationException(string.Format("O nome deve possuir no máximo {0} caratctes", NameMaxLength));

            Name = name;
        }

        public void SetPhone(Phone phone)
        {
            if (phone == null)
                Phone = new Phone();
            else
                Phone = phone;
        }

        public void SetRg(Rg rg)
        {
            if (rg == null)
                Rg = new Rg();
            else
                Rg = rg;
        }

        public void SetAddress(Address address)
        {
            if (address == null)
                Address = new Address();
            else
                Address = address;
        }

        #endregion
    }
}