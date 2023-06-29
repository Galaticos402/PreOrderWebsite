using DataLayer.Models;
using DataLayer.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;   
        public AuthenticationController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInfo loginInfo)
        {
            var account = new Account
            {
                AccountId = 1,
                UserName = loginInfo.UserName,
            };
            String role;
            if (loginInfo.UserName.Contains("a"))
            {
                role = "USER";
            }
            else
            {
                role = "ADMIN";
            }
            // Create claims for the authenticated user
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
            new Claim(ClaimTypes.Name, account.UserName),
            new Claim(ClaimTypes.Role, role)
            // Add additional claims as needed
        };

            // Generate JWT token
            var token = GenerateJwtToken(claims);

            // Return the token to the client
            return Ok(new { Token = token });
        }
        [HttpGet("user")]
        [Authorize(Roles ="USER")]
        public IActionResult GetUser()
        {
            return Ok("OK bitch User");
        }
        [HttpGet("admin")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAdmin()
        {
            return Ok("OK bitch Admin");
        }
        private string GenerateJwtToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Authentication:Issuer"],
                                            _configuration["Authentication:Audience"],
                                            claims, expires: DateTime.UtcNow.AddDays(1),
                                            signingCredentials: signIn);
            var writedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return writedToken;
        }
    }
   
    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
