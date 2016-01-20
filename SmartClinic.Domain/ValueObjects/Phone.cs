using System;

namespace SmartClinic.Domain.ValueObjects
{
    public class Phone
    {
        #region Constructor

        public Phone()
        {
        }

        public Phone(string number)
        {
            SetNumber(number);
        }

        public Phone(string number, string ddd)
        {
            SetNumber(number);
            SetDdd(ddd);
        }

        public Phone(int number)
        {
            SetNumber(number);
        }

        public Phone(int number, int ddd)
        {
            SetNumber(number);
            SetDdd(ddd);
        }

        #endregion

        #region Constants

        public const int DddMaxLength = 3;
        public const int NumberMaxLength = 9;

        #endregion

        #region Properties

        public string Ddd { get; private set; }
        public string Number { get; private set; }

        #endregion

        #region Methods

        public void SetNumber(string number)
        {
            if(string.IsNullOrEmpty(number))
                throw new InvalidOperationException("Numero de telefone não pode ser nulo ou vazio");

            if(number.Length > NumberMaxLength)
                throw new InvalidOperationException(string.Format("Numero do telefone deve ter no máximo {0} caracteres", NumberMaxLength));

            Number = number;
        }

        public void SetNumber(int number)
        {
            if (number.ToString().Length > NumberMaxLength)
                throw new InvalidOperationException(string.Format("Numero do telefone deve ter no máximo {0} caracteres", NumberMaxLength));


            Number = number.ToString();
        }

        public void SetDdd(string ddd)
        {
            if (ddd.Length > DddMaxLength)
                throw new InvalidOperationException(string.Format("DDD deve ter no máximo {0} caracteres", DddMaxLength));

            Ddd = ddd;
        }

        public void SetDdd(int ddd)
        {
            if (ddd.ToString().Length > DddMaxLength)
                throw new InvalidOperationException(string.Format("DDD deve ter no máximo {0} caracteres", DddMaxLength));

            Ddd = ddd.ToString();
        }

        public bool HasDdd()
        {
            return !string.IsNullOrEmpty(Ddd.ToString());
        }

        public string GetFullPhone()
        {
            return string.Format("{0} {1}", Ddd, Number);
        }

        #endregion
    }
}