using IdentityandDataProtection.Context;
using IdentityandDataProtection.Dtos;
using IdentityandDataProtection.Models;
using IdentityandDataProtection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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
        
    }
}
