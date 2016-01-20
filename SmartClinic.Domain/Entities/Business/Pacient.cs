using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Entities.Business
{
    public class Pacient : BaseEntity
    {
        #region Constants

        public const int NameMaxLength = 180;

        #endregion

        #region Constructor

        //Construtor EntityFramework
        protected Pacient()
        {
        }

        public Pacient(string name, Address address, Phone phone, Rg rg, Sex sex, Covenant covenant)
        {
            SetName(name);
            SetAddress(address);
            SetPhone(phone);
            SetRg(rg);
            Sex = sex;
            SetCovenant(covenant);
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public Rg Rg { get; set; }
        public Sex Sex { get; private set; }
        public Guid ConvenantId { get; private set; }
        public virtual Covenant Covenant { get; private set; }

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Nome do paciente não pode ser nulo ou vazio");
            
            if(name.Length > NameMaxLength)
                throw new InvalidOperationException(string.Format("O nome do paciente deve possuir no máximo {0} caratctes", NameMaxLength));

            Name = name;
        }

        public void SetCovenant(Covenant covenant)
        {
            if(covenant == null)
                throw new ArgumentNullException("covenant");
            
            if(!covenant.IsActive())
                throw new InvalidOperationException("O convenio associado ao paciente não está nas condições validas");

            Covenant = covenant;
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