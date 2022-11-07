using LFF.Core.DTOs.Lessons.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Tests.Responses
{
    public class TestResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? NumberOfAttempts { get; set; }

        public int? Time { get; set; }

        public LessonResponse Lesson { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public TestResponse(Test test)
        {
            if (test == null)
                return;

            this.Id = test.Id;
            this.Name = test.Name;
            this.Description = test.Description;
            this.StartDate = test.StartDate;
            this.EndDate = test.EndDate;
            this.NumberOfAttempts = test.NumberOfAttempts;
            this.Time = test.Time;
            this.Lesson = new LessonResponse(test.Lesson);
            this.DeletedAt = test.DeletedAt;
            this.CreatedAt = test.CreatedAt;
            this.LastUpdatedAt = test.LastUpdatedAt;
        }
    }
}
