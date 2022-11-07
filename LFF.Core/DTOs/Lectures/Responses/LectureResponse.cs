using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Lectures.Responses
{
    public class LectureResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Content { get; set; }

        public Guid? LessonId { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public LectureResponse(Lecture lecture)
        {
            if (lecture == null)
                return;

            this.Id = lecture.Id;
            this.Name = lecture.Name;
            this.Description = lecture.Description;
            this.Content = lecture.Content;
            this.LessonId = lecture.LessonId;
            this.DeletedAt = lecture.DeletedAt;
            this.CreatedAt = lecture.CreatedAt;
            this.LastUpdatedAt = lecture.LastUpdatedAt;
        }
    }
}
