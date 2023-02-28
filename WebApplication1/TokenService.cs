using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication1.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
namespace WebApplication1;

    public class TokenService
    {
        private const int ExpirationMinutes = 30;
        public string CreateToken(User user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            var token = CreateJwtToken(CreateSigningCredentials(), expiration);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken( SigningCredentials credentials, DateTime expiration) =>
            new(
                "apiWithAuthBackend",
                "apiWithAuthBackend",
                expires: expiration,
                signingCredentials: credentials
            );
        
        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("?SomethingSecret?")
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
