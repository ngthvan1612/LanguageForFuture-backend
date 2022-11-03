using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Entities;
using System;

namespace LFF.Helpers.Authorization.Users
{
    public class AdminUser : AbstractUser
    {
        public AdminUser(User user)
          : base(user)
        {
            if (user.Role != "ADMIN")
                throw new ArgumentException($"user.Role must be 'ADMIN' in AdminUser class");
        }
    }
}
