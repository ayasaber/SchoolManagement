using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtTokenService;

        public AuthController(IJwtAuthService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken([FromBody] LoginModel user)
        {
            var loginResult =await _jwtTokenService.GetToken(user);

            return loginResult is null ? Unauthorized() : Ok(loginResult);
        }
    }
}
