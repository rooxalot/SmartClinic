using System;

namespace SmartClinic.Domain.ValueObjects
{
    public class Rg
    {
        #region Properties

        public long? Code { get; private set; }

        #endregion

        #region Methods

        public static Rg CreateRg(string rgCode)
        {
            var rg = new Rg();
            rg.SetRg(rgCode);

            return rg;
        }

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

        public void SetRg(string code)
        {
            if (!string.IsNullOrEmpty(code) && (code.Length < RgMinLength || code.Length > RgMaxLength))
                throw new InvalidOperationException(string.Format("O Rg deve possuir entre {0} e {1} caracteres", RgMinLength, RgMaxLength));

            Code = string.IsNullOrEmpty(code) ? 0 : Convert.ToInt64(code);
        }

        #endregion

        #region Constants

        public const int RgMinLength = 9;
        public const int RgMaxLength = 10;

        #endregion

        #region Constructor

        public Rg() {}

        public Rg(string code)
        {
            SetRg(code);
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