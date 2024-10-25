using IdentityandDataProtection.Entities;

namespace IdentityandDataProtection.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType Role  { get; set; }
    }
}
