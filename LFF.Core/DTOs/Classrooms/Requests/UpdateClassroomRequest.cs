using System;

namespace LFF.Core.DTOs.Classrooms.Requests
{
    public class UpdateClassroomRequest
    {
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public int? NumberOfLessons { get; set; }

        public Guid CourseId { get; set; }

        public Guid TeacherId { get; set; }

    }
}
