﻿using IdentityandDataProtection.Dtos;
using IdentityandDataProtection.Types;

namespace IdentityandDataProtection.Services
{
    public interface IIdentityService
    {
        Task<ServiceMessage> AddUser(AddIdentityDto user);

    }
}