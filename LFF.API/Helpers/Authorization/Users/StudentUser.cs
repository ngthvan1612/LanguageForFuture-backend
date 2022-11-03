using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Entities;
using System;

namespace LFF.Helpers.Authorization.Users
{
    public class StudentUser : AbstractUser
    {

        public StudentUser(User user)
          : base(user)
        {
            if (user.Role != "STUDENT")
                throw new ArgumentException($"user.Role must be 'STUDENT' in StudentUser class");
        }
    }
}
