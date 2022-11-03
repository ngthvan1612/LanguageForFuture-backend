using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Entities;
using System;

namespace LFF.Helpers.Authorization.Users
{
    public class StaffUser : AbstractUser
    {
        public StaffUser(User user)
          : base(user)
        {
            if (user.Role != "STAFF")
                throw new ArgumentException($"user.Role must be 'STAFF' in StaffUser class");
        }
    }
}
