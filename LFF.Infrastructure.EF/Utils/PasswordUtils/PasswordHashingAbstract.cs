using System;
using System.Linq;

namespace LFF.Infrastructure.EF.Utils.PasswordUtils
{
    public abstract class PasswordHashingAbstract : IPasswordHashingAlgorithm
    {
        protected abstract string GetHashedPassword(string rawPassword, string salt);
        public abstract string GetProviderName();

        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        private string GetSalt()
        {
            return Guid.NewGuid().ToString();
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable
                .Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray());
        }

        public virtual string GetHashedPasswordWithProvider(string rawPassword)
        {
            string salt = this.GetSalt();
            return $"{this.GetProviderName()}${salt}${this.GetHashedPassword(rawPassword, salt)}";
        }

        public virtual bool CheckPassword(string rawPassword, string hashedPassword)
        {
            string[] temp = hashedPassword.Split("$");
            if (temp.Length != 3)
                return false;
            string salt = temp[1];
            return $"{this.GetProviderName()}${salt}${this.GetHashedPassword(rawPassword, salt)}" == hashedPassword;
        }

        public virtual bool IsMadeByMe(string hashedPassword)
        {
            return hashedPassword.Split("$").First() == this.GetProviderName();
        }

        public virtual void Dispose()
        {

        }
    }
}
