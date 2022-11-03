using System;

namespace LFF.Core.DTOs.Lessons.Requests
{
    public class CreateLessonRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Guid ClassId { get; set; }

    }
}
