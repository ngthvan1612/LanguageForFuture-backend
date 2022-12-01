using System;
using System.Collections.Generic;
using System.Text;

namespace LFF.Core.Entities.Supports
{
    public class ClassroomWithNumberOfStudents
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public int? NumberOfStudents { get; set; }
        public Course? Course { get; set; }
        public User? Teacher { get; set; }

    }
}
