using IdentityandDataProtection.Context;
using IdentityandDataProtection.Dtos;
using IdentityandDataProtection.Jwt;
using IdentityandDataProtection.Models;
using IdentityandDataProtection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = IdentityandDataProtection.Models.RegisterRequest;

namespace IdentityandDataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IdentityandDataProtectionDbContext _context;
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var addIdentityDto = new AddIdentityDto
            {
                Email = request.Email,
                Password = request.Password,

            };
            var result = await _identityService.AddUser(addIdentityDto);

            if (result.IsSucceed)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginRequest request)
        {
            var LoginUserDto = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password,
            };
            var result = await _identityService.LoginUser(LoginUserDto);

            if ( !result.IsSucceed)
                return BadRequest(result.Message);
            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwt(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                SecretKey = configuration["Jwt:SecretKey"]!,
                Issuer = configuration["Jwt: Issuer "]!,
                Auidence = configuration["Jwt: Audience"]!,
                ExpireMinutes = int.Parse(configuration["Jwt: ExpireMinutes"]!)
            });


            return Ok(new LoginResponse
            {
                Message ="Giriş başarılı",
                Token = token
            });
        }

       
        
    }
}
