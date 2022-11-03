using LFF.Core.Entities;
using System;

namespace LFF.API.Helpers.Authorization.Users
{
    public abstract class AbstractUser
    {
        public Guid Id { get; }
        public string Username { get; }
        public string Role { get; }
        public string Email { get; }

        private readonly bool isAuthenticated;

        public AbstractUser()
        {
            this.Username = "<Unknown>";
            this.Role = "<Unknown>";
            this.Email = "<Unknown>";
            this.Id = Guid.Empty;
            this.isAuthenticated = false;
        }

        public AbstractUser(User user)
        {
            this.Username = user.Username;
            this.Role = user.Role;
            this.Email = user.Email;
            this.Id = (Guid)user.Id;
            this.isAuthenticated = true;
        }

        public bool IsAuthenticated() => this.isAuthenticated;
        public bool IsAdmin() => this.Role == "ADMIN";
        public bool IsStaff() => this.Role == "STAFF";
        public bool IsTeacher() => this.Role == "TEACHER";
        public bool IsStudent() => this.Role == "STUDENT";
    }
}
