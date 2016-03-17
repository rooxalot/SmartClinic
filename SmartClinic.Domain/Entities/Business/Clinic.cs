using System;
using SmartClinic.Domain.Entities.Base;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Domain.Entities.Business
{
    public class Clinic : BaseEntity
    {
        #region Constructor

        //Entity EntityFramework
        protected Clinic()
        {
        }

        public Clinic(string name, string header, Cnpj cnpj, Phone phone)
        {
            SetName(name);
            SetHeader(header);
            SetCnpj(cnpj);
            SetPhone(phone);
        }

        #endregion

        #region Properties

        public string Name { get; private set; }
        public string Header { get; private set; }
        public Cnpj Cnpj { get; set; }
        public Phone Phone { get; set; }

        #endregion

        #region Constants

        public const int NameMinLength = 2;
        public const int NameMaxLength = 150;

        public const int HeaderMaxLength = 100;

        #endregion

        #region Methods

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Nome da clinica não pode ser nulo ou vazio");

            if(name.Length < NameMinLength || name.Length > NameMaxLength)
                throw new InvalidOperationException(string.Format("O nome da clinica deve possuir entre {0} e {1} caracteres", NameMinLength, NameMaxLength));

            Name = name;
        }

        public void SetHeader(string header)
        {
            if(header == null)
                throw new ArgumentNullException("header");
            
            if(header.Length > HeaderMaxLength)
                throw new InvalidOperationException(string.Format("O nome da clinica deve possuir no máximo {0} caracteres", HeaderMaxLength));

            Header = header;
        }

        public void SetCnpj(Cnpj cnpj)
        {
            Cnpj = cnpj ?? new Cnpj();
        }

        public void SetPhone(Phone phone)
        {
            Phone = phone ?? new Phone();
        }

        #endregion
    }
}