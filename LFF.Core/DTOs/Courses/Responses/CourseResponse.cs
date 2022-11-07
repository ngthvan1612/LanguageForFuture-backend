using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Courses.Responses
{
    public class CourseResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public CourseResponse(Course course)
        {
            if (course == null)
                return;

            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
            this.DeletedAt = course.DeletedAt;
            this.CreatedAt = course.CreatedAt;
            this.LastUpdatedAt = course.LastUpdatedAt;
        }
    }
}
