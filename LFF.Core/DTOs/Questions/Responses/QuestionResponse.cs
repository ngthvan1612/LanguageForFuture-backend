using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class QuestionResponse
    {
        public Guid? Id { get; set; }

        public string? Content { get; set; }

        public string? QuestionType { get; set; }

        public Guid? TestId { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public QuestionResponse(Question question)
        {
            this.Id = question.Id;
            this.Content = question.Content;
            this.QuestionType = question.QuestionType;
            this.TestId = question.TestId;
            this.DeletedAt = question.DeletedAt;
            this.CreatedAt = question.CreatedAt;
            this.LastUpdatedAt = question.LastUpdatedAt;
        }
    }
}
