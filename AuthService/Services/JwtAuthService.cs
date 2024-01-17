using AuthService.Entities;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{

    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly List<UserData> _users = new()
        {
        new("admin", "aDm1n", "Administrator", new[] {"course","student"}),
        new("user01", "u$3r01", "User", new[] {"teacher"})
        };
        private const string SecurityKey = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";


        public JwtAuthService(IConfiguration configuration)
        {
            //this.Key = key;
            _configuration = configuration;
        }

        public async Task<Response<string>> GetToken(LoginModel userModel)
        {
            var user = _users.FirstOrDefault(u => u.Username == userModel.UserName
                                  && u.Password == userModel.Password);

            if (user is null)
            {
                return null;
            }
            int? expires = 1;

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.ASCII.GetBytes(SecurityKey);

            var claims = GetClaims(user);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer= "https://localhost:7212",
                Audience= "https://localhost:7086",
                Expires = expires != null ? (DateTime?)DateTime.UtcNow.AddDays(expires.Value) : null,

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return new Response<string>(jwtSecurityTokenHandler.WriteToken(token), true);
        }
        private List<Claim> GetClaims(UserData user)
        {
            var claims = new List<Claim>();
            var identityClaim = new Claim(ClaimTypes.Name, user.Username);
            claims.Add(identityClaim);

            foreach (var claim in user.Scopes)
            {
                claims.Add(new Claim("scope", claim));

            }
            return claims;

        }
    }

}
