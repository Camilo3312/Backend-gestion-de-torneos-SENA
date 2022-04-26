using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web_API;
using work4hours_modules_backend.Models;

namespace Gestion_de_torneos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        MySqlDatabase _db = new MySqlDatabase();
        private readonly IConfiguration _configuration;

        public object AdapterTable { get; private set; }

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginData login_data)
        {
            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();

            var query = $"select id, nombre, correo from usuarioadmin where correo = '{login_data.correo}' and contrasenna = '{login_data.contrasenna}' ;";
            string result = _db.ConvertDataTabletoString(query);
            if (result == "[]")
            {
                return BadRequest(new { isAuth = false });
            }
            else
            {

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createdToken);

                return Ok(new { isAuth = true, data = result , token = token  });
            }
        }
    }
}