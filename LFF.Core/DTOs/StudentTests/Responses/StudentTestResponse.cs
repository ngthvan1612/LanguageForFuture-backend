using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class StudentTestResponse
    {
        public Guid? Id { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? TestId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public StudentTestResponse(StudentTest studentTest)
        {
            this.Id = studentTest.Id;
            this.StudentId = studentTest.StudentId;
            this.TestId = studentTest.TestId;
            this.StartDate = studentTest.StartDate;
            this.DeletedAt = studentTest.DeletedAt;
            this.CreatedAt = studentTest.CreatedAt;
            this.LastUpdatedAt = studentTest.LastUpdatedAt;
        }
    }
}
