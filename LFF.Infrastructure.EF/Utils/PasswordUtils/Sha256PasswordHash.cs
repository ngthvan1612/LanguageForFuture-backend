using System.Security.Cryptography;
using System.Text;

namespace LFF.Infrastructure.EF.Utils.PasswordUtils
{
    public class Sha256PasswordHash : PasswordHashingAbstract
    {
        private readonly SHA256 sha256Instance = SHA256.Create();

        protected override string GetHashedPassword(string rawPassword, string salt)
        {
            rawPassword += salt;
            byte[] inputBytes = Encoding.Unicode.GetBytes(rawPassword);
            byte[] hashBytes = this.sha256Instance.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            foreach (var elm in hashBytes)
            {
                sb.Append(elm.ToString("x2"));
            }

            return sb.ToString();
        }

        public override string GetProviderName()
        {
            return "sha256.lowercase";
        }
    }
}
