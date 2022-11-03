using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class LessonResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Guid? ClassId { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public LessonResponse(Lesson lesson)
        {
            this.Id = lesson.Id;
            this.Name = lesson.Name;
            this.Description = lesson.Description;
            this.StartTime = lesson.StartTime;
            this.EndTime = lesson.EndTime;
            this.ClassId = lesson.ClassId;
            this.DeletedAt = lesson.DeletedAt;
            this.CreatedAt = lesson.CreatedAt;
            this.LastUpdatedAt = lesson.LastUpdatedAt;
        }
    }
}
