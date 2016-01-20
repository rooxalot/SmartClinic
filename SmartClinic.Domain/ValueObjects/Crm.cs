using System;
using SmartClinic.Domain.Enums;

namespace SmartClinic.Domain.ValueObjects
{
    public class Crm
    {
        #region Constants

        public const int CrmMaxLength = 10;

        #endregion

        #region Constructor

        /*Construtor EntityFramework*/
        protected Crm()
        {
            
        }

        public Crm(string code, Uf uf)
        {
            SetCode(code);
            Uf = uf;
        }

        public Crm(double code, Uf uf)
        {
            SetCode(code);
            Uf = uf;
        }

        #endregion

        #region Properties

        public long Code { get; private set; }

        public Uf Uf { get; set; }

        #endregion

        #region Methods

        public void SetCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new InvalidOperationException("Código do CRM não pode ser nulo ou vazio");

            double numeric;
            if(!double.TryParse(code, out numeric))
                throw new InvalidOperationException("O código do CRM deve ser numérico");

            if (code.Length > CrmMaxLength)
                throw new InvalidOperationException(string.Format("O código do CRM deve possuir no máximo {0} digitos", CrmMaxLength));

            Code = Convert.ToInt64(code);
        }

        public void SetCode(double code)
        {
            if (code.ToString().Length > CrmMaxLength)
                throw new InvalidOperationException(string.Format("O código do CRM deve possuir no máximo {0} digitos", CrmMaxLength));

            Code = Convert.ToInt64(code);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (Crm))
                return false;

            var objCrm = (Crm) obj;
            return objCrm.Code == Code && objCrm.Uf == Uf;
        }

        public override string ToString()
        {
            return Code + "/" + Uf;
        }

        #endregion
    }
}