using System;

namespace LFF.Core.DTOs.Lectures.Requests
{
    public class CreateLectureRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Content { get; set; }

        public Guid LessonId { get; set; }

    }
}
