using System;

namespace LFF.Core.DTOs.Questions.Requests
{
    public class UpdateQuestionRequest
    {
        public string? Content { get; set; }

        public string? QuestionType { get; set; }

        public Guid TestId { get; set; }

    }
}
