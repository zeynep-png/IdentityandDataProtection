using System.ComponentModel.DataAnnotations;

namespace IdentityandDataProtection.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
