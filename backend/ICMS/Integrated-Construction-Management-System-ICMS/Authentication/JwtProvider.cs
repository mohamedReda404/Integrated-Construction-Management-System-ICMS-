
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Integrated_Construction_Management_System_ICMS.Authentication
{
    public class JwtProvider(IConfiguration configuration) : IJwtProvider
    {
        private readonly IConfiguration _configuration = configuration;

        public (string token, int expirsIn) GenerateToken(ApplicationUser user)
        {
            Claim[] _claims =
            {
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sk_live_TVN1rkjqmdbjSTV2McHrKctC8csmbbPC"));
            var singingCradentail = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expirisIn = 30;
            var expirsInDate= DateTime.UtcNow.AddMinutes(expirisIn);

            var _token = new JwtSecurityToken
            (
                issuer: "Integrated_Construction_Management_System_ICMS",
                audience: "Integrated_Construction_Management_System_ICMS Users",
                claims:_claims,
                expires:expirsInDate,
                signingCredentials:singingCradentail
             );

            return (token: new JwtSecurityTokenHandler().WriteToken(_token), expirsIn: expirisIn);
        }
    }
}
