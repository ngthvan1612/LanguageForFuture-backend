using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class RegisterResponse
    {
        public Guid? Id { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? ClassId { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public RegisterResponse(Register register)
        {
            this.Id = register.Id;
            this.StudentId = register.StudentId;
            this.ClassId = register.ClassId;
            this.RegistrationDate = register.RegistrationDate;
            this.DeletedAt = register.DeletedAt;
            this.CreatedAt = register.CreatedAt;
            this.LastUpdatedAt = register.LastUpdatedAt;
        }
    }
}
