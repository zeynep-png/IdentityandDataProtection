using System.ComponentModel.DataAnnotations;

namespace IdentityandDataProtection.Dtos
{
    public class AddIdentityDto
    {
        public string Email { get; set; }

        
        public string Password { get; set; }
    }
}
