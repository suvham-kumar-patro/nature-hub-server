using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nature_hub_server.Data;
using nature_hub_server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NatureHubDbContext _context;

        private readonly IConfiguration _configuration;

        public AuthController(NatureHubDbContext context, IConfiguration configuration)

        {

            _context = context;

            _configuration = configuration;

        }

        [HttpPost("login")]

        public IActionResult Login(User login)

        {

            var user = _context.Users.SingleOrDefault

                (u => u.UName == login.UName && u.UPassword == login.UPassword);

            if (user == null) { return Unauthorized(); }

            var token = GenerateJwtToken(user);

            return Ok(new { token });

        }

        private string GenerateJwtToken(User user)

        {

            var claims = new[] {

         new Claim(ClaimTypes.Name,user.UName),

    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _configuration["Jwt:Issuer"],

                audience: _configuration["Jwt:Audience"],

                claims: claims,

                expires: DateTime.Now.AddMinutes(5),

                signingCredentials: credential

                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
