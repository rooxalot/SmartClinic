using System.Linq;
using System.Text;

namespace SmartClinic.Infrastructure.CrossCutting.Validation
{
    public class Validator
    {
        public static string GetNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var sb = new StringBuilder("");
            var charArray = value.ToCharArray();

            foreach (var character in charArray.Where(character => !double.IsNaN(character)))
                sb.Append(character);

            return sb.ToString();
        }

        public static bool IsNumeric(string value)
        {
            double number;
            return double.TryParse(value, out number);
        }
    }
}