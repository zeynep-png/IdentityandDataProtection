using IdentityandDataProtection.Context;
using IdentityandDataProtection.Dtos;
using IdentityandDataProtection.Entities;
using IdentityandDataProtection.Services;
using IdentityandDataProtection.Types;

namespace IdentityandDataProtection.Managers
{
    public class IdentityManager : IIdentityService
    {
        private readonly IdentityandDataProtectionDbContext _db;
        public IdentityManager(IdentityandDataProtectionDbContext db)
        {
            _db = db;

            
        }
        public async Task<ServiceMessage> AddUser(AddIdentityDto user)
        {
            var newUser = new UserEntity
            {
                Email = user.Email,
                Password = user.Password,
            };
            _db.Users.Add(newUser);
            _db.SaveChanges();

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Kayıt oluşturuldu"
            };
        }
    }
}
