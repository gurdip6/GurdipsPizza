using Microsoft.IdentityModel.Tokens;
using PizzaAPI.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaAPI.Middleware
{
    public class JwtExtension
    {
        private readonly IConfiguration _configuration;
        private readonly string? _key;
        private readonly string? _issuer;
        private readonly string? _audience;

        public JwtExtension(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = configuration.GetValue<string>("JWT:Key");
            _issuer = configuration.GetValue<string>("JWT:Issuer");
            _audience = configuration.GetValue<string>("JWT:Audience");
        }

        public string CreateJwtToken(AccountEntity accountEntity)
        {
            var claims = new List<Claim> {
        new Claim(ClaimTypes.NameIdentifier, accountEntity.AccountID.ToString()),
        new Claim(ClaimTypes.Name, accountEntity.Username),
        new Claim(ClaimTypes.Email, accountEntity.Email),
        new Claim(ClaimTypes.MobilePhone, accountEntity.Phone)
    };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                audience: _audience,
                issuer: _issuer,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(_key)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
