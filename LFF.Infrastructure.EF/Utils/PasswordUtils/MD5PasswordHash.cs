using System.Security.Cryptography;
using System.Text;

namespace LFF.Infrastructure.EF.Utils.PasswordUtils
{
    public class Md5PasswordHash : PasswordHashingAbstract
    {
        private readonly MD5 md5Instance = MD5.Create();

        protected override string GetHashedPassword(string rawPassword, string salt)
        {
            rawPassword += salt;
            byte[] inputBytes = Encoding.Unicode.GetBytes(rawPassword);
            byte[] hashBytes = this.md5Instance.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            foreach (var elm in hashBytes)
            {
                sb.Append(elm.ToString("x2"));
            }

            return sb.ToString();
        }

        public override string GetProviderName()
        {
            return "md5.lowercase";
        }
    }
}
