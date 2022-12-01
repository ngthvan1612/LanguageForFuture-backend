using System;
using System.Collections.Generic;
using System.Text;

namespace LFF.Core.DTOs.Users.Requests
{
    public class UpdatePasswordRequest
    {
        public Guid UserId { get; set; }
        public string? Password { get; set; }
    }
}
