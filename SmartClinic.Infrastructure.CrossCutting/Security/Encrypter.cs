using System.Security.Cryptography;
using System.Text;

namespace SmartClinic.Infrastructure.CrossCutting.Security
{
    public class Encrypter
    {
        private static readonly MD5 Cryptografer = MD5.Create();

        public static string Encrypt(string value)
        {
            var stringBytes = Encoding.ASCII.GetBytes(value);
            var hash = Cryptografer.ComputeHash(stringBytes);

            var sb = new StringBuilder();
            foreach (var h in hash)
                sb.Append(h.ToString("x2"));

            return sb.ToString();
        }
    }
}