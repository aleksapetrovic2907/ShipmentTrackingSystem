using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Logs the user in and generates a JWT token.
        /// </summary>
        /// <returns>A JWT token for authenticated access.</returns>
        /// <response code="200">Returns the generated JWT token.</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login()
        {
            var token = GenerateJwtToken();
            return Ok(new { Token = token });
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        /// <returns>A success message for logout operation.</returns>
        /// <response code="200">Indicates successful logout.</response>
        [HttpPost("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Logout()
        {
            return Ok(new { Message = "Logged out successfully" });
        }

        private string GenerateJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKeyThatCanBeReadByAnyoneOnGithub"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, "User")
                },
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
