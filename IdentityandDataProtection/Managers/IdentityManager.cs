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

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto user)
        {
            var userEntity = _db.Users.Where(x => x.Email == user.Email.ToString()).FirstOrDefault();
            if (userEntity != null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı veya şifre hatalı"
                };
            }
            if (userEntity.Password == user.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Id = userEntity.Id,
                        Email = userEntity.Email,
                        Role = userEntity.Role,
                    }
                };
            }
            else
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };
        }
    }
}
