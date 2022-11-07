using LFF.Core.DTOs.Courses.Responses;
using LFF.Core.DTOs.Users.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class ClassroomResponse
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public int? NumberOfLessons { get; set; }

        public CourseResponse Course { get; set; }
        public UserResponse Teacher { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public ClassroomResponse(Classroom classroom)
        {
            if (classroom == null)
                return;

            this.Id = classroom.Id;
            this.Name = classroom.Name;
            this.StartDate = classroom.StartDate;
            this.NumberOfLessons = classroom.NumberOfLessons;
            this.Course = new CourseResponse(classroom.Course);
            this.Teacher = new UserResponse(classroom.Teacher);
            this.DeletedAt = classroom.DeletedAt;
            this.CreatedAt = classroom.CreatedAt;
            this.LastUpdatedAt = classroom.LastUpdatedAt;
        }
    }
}
