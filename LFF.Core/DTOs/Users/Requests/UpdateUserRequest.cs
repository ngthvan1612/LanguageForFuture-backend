using System;

namespace LFF.Core.DTOs.Users.Requests
{
    public class UpdateUserRequest
    {
        public string? Username { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? CMND { get; set; }

        public string? Role { get; set; }

    }
}
