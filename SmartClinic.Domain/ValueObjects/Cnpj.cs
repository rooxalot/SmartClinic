using System;

namespace SmartClinic.Domain.ValueObjects
{
    public class Cnpj
    {
        #region Constants

        public const int CnpjMaxLength = 14;

        #endregion

        #region Properties

        public string Code { get; private set; }

        #endregion

        #region Constructor

        public Cnpj()
        {
            
        }

        public Cnpj(string code)
        {
            SetCode(code);
        }

        public Cnpj(double code)
        {
            SetCode(code);
        }

        #endregion

        #region Methods

        public void SetCode(string code)
        {
            if(string.IsNullOrEmpty(code))
                throw new InvalidOperationException("Código do CNPJ não pode ser nulo ou vazio");

            double numeric;
            if (!double.TryParse(code, out numeric))
                throw new InvalidOperationException("O código do CNPJ deve ser um valor numérico");

            if (code.Contains("."))
                throw new InvalidOperationException("O CNPJ não pode possuir ponto flutuante");

            if(code.Length < CnpjMaxLength || code.Length > CnpjMaxLength)
                throw new InvalidOperationException(string.Format("CNPJ deve possuir {0} caracteres", CnpjMaxLength));

            Code = code;
        }

        public void SetCode(double code)
        {
            if (code.ToString().Length < CnpjMaxLength || code.ToString().Length > CnpjMaxLength)
                throw new InvalidOperationException(string.Format("CNPJ deve possuir {0} caracteres", CnpjMaxLength));

            if (code.ToString().Contains("."))
                throw new InvalidOperationException("O CNPJ não pode possuir ponto flutuante");

            Code = code.ToString();
        }

        #endregion
    }
}