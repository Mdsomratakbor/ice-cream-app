using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Icecream.Api.Services
{
    public class TokenService
    {
        /*JWT
         * SecretKey
         * Audience
         * Issuer
         * Expiration
         */
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwt(Guid userId, string userName, string email, string address)
        {
            var secreteKey = _configuration["Jwt:SecretKey"];
            if (secreteKey != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var issuer = _configuration["Jwt:Issuer"];
                var expireInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinute"]);

                Claim[] claims = [
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.StreetAddress, address)
                    ];

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: "*",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(expireInMinutes),
                    signingCredentials: credentials);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return jwt;
            }
            else
            {
                return "Please set the secrete key";
            }
        }
    }
}
