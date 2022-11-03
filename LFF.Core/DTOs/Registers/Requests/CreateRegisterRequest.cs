using System;

namespace LFF.Core.DTOs.Registers.Requests
{
    public class CreateRegisterRequest
    {
        public Guid StudentId { get; set; }

        public Guid ClassId { get; set; }

        public DateTime? RegistrationDate { get; set; }

    }
}
