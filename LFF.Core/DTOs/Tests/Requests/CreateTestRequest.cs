using System;

namespace LFF.Core.DTOs.Tests.Requests
{
    public class CreateTestRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? NumberOfAttempts { get; set; }

        public int? Time { get; set; }

        public Guid LessonId { get; set; }

    }
}
