using LFF.Core.DTOs.Questions.Responses;
using LFF.Core.DTOs.StudentTests.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class StudentTestResultResponse
    {
        public Guid? Id { get; set; }

        public StudentTestResponse StudentTest { get; set; }

        public QuestionResponse Question { get; set; }

        public string? Result { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public StudentTestResultResponse(StudentTestResult studentTestResult)
        {
            if (studentTestResult == null)
                return;

            this.Id = studentTestResult.Id;
            this.StudentTest = new StudentTestResponse(studentTestResult.StudentTest);
            this.Question = new QuestionResponse(studentTestResult.Question);
            this.Result = studentTestResult.Result;
            this.DeletedAt = studentTestResult.DeletedAt;
            this.CreatedAt = studentTestResult.CreatedAt;
            this.LastUpdatedAt = studentTestResult.LastUpdatedAt;
        }
    }
}
