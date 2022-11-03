using System;

namespace LFF.Core.DTOs.StudentTestResults.Requests
{
    public class UpdateStudentTestResultRequest
    {
        public Guid StudentTestId { get; set; }

        public Guid QuestionId { get; set; }

        public string? Result { get; set; }

    }
}
