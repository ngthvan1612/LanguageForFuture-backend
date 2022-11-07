using System;

namespace LFF.Core.DTOs.Registers.Requests
{
    public class UpdateRegisterRequest
    {
        public Guid StudentId { get; set; }

        public Guid ClassId { get; set; }
    }
}
