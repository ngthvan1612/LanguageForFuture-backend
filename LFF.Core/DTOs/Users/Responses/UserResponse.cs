using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Users.Responses
{
    public class UserResponse
    {
        public Guid? Id { get; set; }

        public string? Username { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? CMND { get; set; }

        public string? Role { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public UserResponse(User user)
        {
            if (user == null)
                return;

            this.Id = user.Id;
            this.Username = user.Username;
            this.FullName = user.FullName;
            this.Email = user.Email;
            this.DateOfBirth = user.DateOfBirth;
            this.CMND = user.CMND;
            this.Role = user.Role;
            this.DeletedAt = user.DeletedAt;
            this.CreatedAt = user.CreatedAt;
            this.LastUpdatedAt = user.LastUpdatedAt;
        }
    }
}
