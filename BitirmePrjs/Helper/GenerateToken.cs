using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace BitirmePrjs.Helper
{
    public class GenerateToken
    {
        public string GenerateJwtToken(string email, string rol)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bitirmeASD@@bitirme!!!12345678@bitirme!!!1234...")); // Key'i dikkatli saklayın
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenExpiration = DateTime.UtcNow.AddDays(1);
            // Rollerinizi ve rollerinizi karşılık gelen yetkiyi burada belirleyin
            var claims = new List<Claim> {
        new Claim(ClaimTypes.Email, email),
    };
            if (rol == "u")
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }
            else if (rol == "a")
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else if (rol == "s")
            {
                claims.Add(new Claim(ClaimTypes.Role, "supervisor"));
            }
            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: tokenExpiration, // Token'ın geçerlilik süresi
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokens = tokenHandler.WriteToken(token);
            return tokens;
        }
    }
}
