using System;

namespace LFF.Infrastructure.EF.Utils.PasswordUtils
{
    public interface IPasswordHashingAlgorithm : IDisposable
    {
        string GetHashedPasswordWithProvider(string rawPassword);
        bool CheckPassword(string rawPassword, string hashedPassword);
        string GetProviderName();
        bool IsMadeByMe(string hashedPassword);
    }
}
