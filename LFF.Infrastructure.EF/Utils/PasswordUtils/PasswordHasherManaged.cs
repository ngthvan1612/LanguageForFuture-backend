using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace LFF.Infrastructure.EF.Utils.PasswordUtils
{
    public class PasswordHasherManaged
    {
        private static readonly Md5PasswordHash md5PasswordHashInstance = new Md5PasswordHash();
        private static readonly Sha256PasswordHash sha256PasswordHashInstance = new Sha256PasswordHash();

        private static readonly ICollection<IPasswordHashingAlgorithm> _algorithms = new List<IPasswordHashingAlgorithm>()
        {
            md5PasswordHashInstance, sha256PasswordHashInstance
        };

        private readonly PasswordSettings passwordSettings;

        public PasswordHasherManaged(IOptions<PasswordSettings> passwordSettings)
        {
            this.passwordSettings = passwordSettings.Value;
        }

        private IPasswordHashingAlgorithm? GetHashingAlgorithmFromHashedPassword(string hashedPassword)
        {
            foreach (var algorithm in _algorithms)
            {
                if (algorithm.IsMadeByMe(hashedPassword))
                {
                    return algorithm;
                }
            }

            return null;
        }

        private IPasswordHashingAlgorithm? GetCurrentPasswordHashingAlgorithm()
        {
            return this.passwordSettings.Algorithm switch
            {
                "SHA256" => sha256PasswordHashInstance,
                "MD5" => md5PasswordHashInstance,
                _ => null
            };
        }

        public string GetHashedPassword(string rawPassword)
        {
            var algorithm = this.GetCurrentPasswordHashingAlgorithm() ?? md5PasswordHashInstance;
            return algorithm.GetHashedPasswordWithProvider(rawPassword);
        }

        public bool CheckPassword(string rawPassword, string hashedPassword)
        {
            var algorithm = this.GetHashingAlgorithmFromHashedPassword(hashedPassword);
            return algorithm is { } && algorithm.CheckPassword(rawPassword, hashedPassword);
        }
    }
}
