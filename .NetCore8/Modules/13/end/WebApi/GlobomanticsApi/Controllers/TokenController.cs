using GlobomanticsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GlobomanticsApi.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        public IConfiguration _configuration;

        public TokenController(IConfiguration config)
        {
            _configuration = config;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginModel loginModel)
        {
            if (!ValidCredentials(loginModel))
            {
                return Unauthorized();
            }

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new Dictionary<string, object>
            {
                { JwtRegisteredClaimNames.Sub, _configuration["Authentication:Subject"] }, 
                { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },  
                { "Email", loginModel.Email },
            };

           var securityDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Authentication:Issuer"],
                Audience = _configuration["Authentication:Audience"],
                Claims = claims,
                NotBefore = DateTime.UtcNow, 
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(securityDescriptor);
            
            return token;
        }

        private bool ValidCredentials(LoginModel loginModel)
        {
            return true;
        }
    }
}
