using IdentityandDataProtection.Entities;
using System.Reflection.PortableExecutable;

namespace IdentityandDataProtection.Jwt
{
    public class JwtDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType  Role { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Auidence { get; set; }
        public int ExpireMinutes { get; set; }
    }
}
