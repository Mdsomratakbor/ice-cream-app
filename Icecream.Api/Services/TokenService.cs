using Icecream.Shared.Dtos;
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

        public string GenerateJwt(LoggedInUserDto user)
        {

          
                var credentials = new SigningCredentials(GetSecurityKey(_configuration), SecurityAlgorithms.HmacSha256);
                var issuer = _configuration["Jwt:Issuer"];
                var expireInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinute"]);

                Claim[] claims = [
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.StreetAddress, user.Address)
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
        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                IssuerSigningKey = GetSecurityKey(configuration)

    };
        }
        public static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secreteKey = configuration["Jwt:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));
            return securityKey;

        }
    }
}
