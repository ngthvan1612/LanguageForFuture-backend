using LFF.Core.DTOs.Classrooms.Responses;
using LFF.Core.DTOs.Users.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class RegisterResponse
    {
        public Guid? Id { get; set; }

        public UserResponse Student { get; set; }
        public ClassroomResponse Class { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public RegisterResponse(Register register)
        {
            if (register == null)
                return;

            this.Id = register.Id;
            this.Student = new UserResponse(register.Student);
            this.Class = new ClassroomResponse(register.Class);
            this.RegistrationDate = register.RegistrationDate;
            this.DeletedAt = register.DeletedAt;
            this.CreatedAt = register.CreatedAt;
            this.LastUpdatedAt = register.LastUpdatedAt;
        }
    }
}
