using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class StudentTestResultResponse
    {
        public Guid? Id { get; set; }

        public Guid? StudentTestId { get; set; }

        public Guid? QuestionId { get; set; }

        public string? Result { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public StudentTestResultResponse(StudentTestResult studentTestResult)
        {
            this.Id = studentTestResult.Id;
            this.StudentTestId = studentTestResult.StudentTestId;
            this.QuestionId = studentTestResult.QuestionId;
            this.Result = studentTestResult.Result;
            this.DeletedAt = studentTestResult.DeletedAt;
            this.CreatedAt = studentTestResult.CreatedAt;
            this.LastUpdatedAt = studentTestResult.LastUpdatedAt;
        }
    }
}
