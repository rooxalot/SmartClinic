using System.Security.Cryptography;
using System.Text;
using SmartClinic.Domain.Interfaces.CrossCutting;

namespace SmartClinic.Infrastructure.CrossCutting.Security
{
    public class Encrypter : IEncrypter
    {
        private static readonly MD5 Cryptografer = MD5.Create();

        public string Encrypt(string value)
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