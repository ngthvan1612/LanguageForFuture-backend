using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Entities;
using System;

namespace LFF.Helpers.Authorization.Users
{
    public class TeacherUser : AbstractUser
    {
        public TeacherUser(User user)
          : base(user)
        {
            if (user.Role != "TEACHER")
                throw new ArgumentException($"user.Role must be 'TEACHER' in TeacherUser class");
        }
    }
}
