using System;

namespace LFF.Core.DTOs.StudentTests.Requests
{
    public class UpdateStudentTestRequest
    {
        public Guid StudentId { get; set; }

        public Guid TestId { get; set; }

    }
}
