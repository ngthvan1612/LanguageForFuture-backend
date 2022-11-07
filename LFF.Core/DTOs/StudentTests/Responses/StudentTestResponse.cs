using LFF.Core.DTOs.Tests.Responses;
using LFF.Core.DTOs.Users.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class StudentTestResponse
    {
        public Guid? Id { get; set; }

        public UserResponse Student { get; set; }
        public TestResponse Test { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public StudentTestResponse(StudentTest studentTest)
        {
            if (studentTest == null)
                return;

            this.Id = studentTest.Id;
            this.Student = new UserResponse(studentTest.Student);
            this.Test = new TestResponse(studentTest.Test);
            this.StartDate = studentTest.StartDate;
            this.DeletedAt = studentTest.DeletedAt;
            this.CreatedAt = studentTest.CreatedAt;
            this.LastUpdatedAt = studentTest.LastUpdatedAt;
        }
    }
}
