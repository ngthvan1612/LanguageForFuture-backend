using System;

namespace LFF.Core.DTOs.StudentTestResults.Requests
{
    public class CreateStudentTestResultRequest
    {
        public Guid StudentTestId { get; set; }

        public Guid QuestionId { get; set; }

        public string? Result { get; set; }

    }
}
