using System;

namespace SmartClinic.Domain.ValueObjects
{
    public class Rg
    {
        #region Properties

        public long? Code { get; private set; }

        #endregion

        #region Methods

        public string GetFormatedRg()
        {
            if (Code == null)
                return null;

            var rgString = Code.ToString();
            var rgStart = rgString.Substring(0, 2);
            var rgMiddle1 = rgString.Substring(2, 3);
            var rgMiddle2 = rgString.Substring(5, 3);
            var rgEnd = rgString.Substring(8);

            return string.Format("{0}.{1}.{2}-{3}", rgStart, rgMiddle1, rgMiddle2, rgEnd);
        }

        #endregion

        #region Constants

        public const int RgMinLength = 9;
        public const int RgMaxLength = 10;

        #endregion

        #region Constructor

        public Rg()
        {
            
        }

        public Rg(string code)
        {
            if(code == string.Empty)
                throw new InvalidOperationException("O Código do Rg não pode ser vazio");

            if(code.Length < RgMinLength || code.Length > RgMaxLength)
                throw new InvalidOperationException(string.Format("O Rg deve possuir entre {0} e {1} caracteres", RgMinLength, RgMaxLength));

            Code = Convert.ToInt64(code);
        }

        public Rg(long code)
        {
            if (code.ToString().Length < RgMinLength || code.ToString().Length > RgMaxLength)
                throw new InvalidOperationException(string.Format("O Rg deve possuir entre {0} e {1} caracteres", RgMinLength, RgMaxLength));


            Code = code;
        }

        #endregion
    }
}