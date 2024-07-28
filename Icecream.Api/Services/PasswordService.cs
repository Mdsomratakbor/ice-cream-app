using System.Security.Cryptography;
using System.Text;

namespace Icecream.Api.Services
{
    public class PasswordService
    {
        private const int SaltSize = 10;
        public (string salt, string hash) GenerateSaltAndHash(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentNullException(nameof(plainPassword));

            var buffer = RandomNumberGenerator.GetBytes(SaltSize);
            var salt = Convert.ToBase64String(buffer);

            return (salt, GeneratedHashedPassword(plainPassword, salt));
        }

        public bool Compare(string plainPassword, string salt, string hashedPassword)
        {
            return GeneratedHashedPassword(plainPassword, salt) == hashedPassword;
        }
        private static string GeneratedHashedPassword(string plainPassword, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(plainPassword + salt);
            var hash = SHA256.HashData(bytes);
            var hashedPassword = Convert.ToBase64String(hash);
            return hashedPassword;
        }
    }
}
