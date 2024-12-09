using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Sistema_Ganimedes.Application.Interfaces;

namespace Sistema_Ganimedes.Application.Services
{

    public class AuthenticationService : IAuthenticationService
    {

        private readonly String secretKey = "erubwerbnwerkbnwerkbn394-134=-8rb23gb";
        private readonly int TokenExpirationMinutes = 240;

        public string GenerateJWTToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", "user")
            };

            var token = new JwtSecurityToken(
                issuer: "sistema-ganimedes",
                audience: "sistema-ganimedes",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(TokenExpirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}
