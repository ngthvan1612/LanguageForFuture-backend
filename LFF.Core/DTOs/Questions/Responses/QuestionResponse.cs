using LFF.Core.DTOs.Tests.Responses;
using LFF.Core.Entities;
using System;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class QuestionResponse
    {
        public Guid? Id { get; set; }

        public string? Content { get; set; }

        public string? QuestionType { get; set; }

        public TestResponse Test { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public QuestionResponse(Question question)
        {
            if (question == null)
                return;

            this.Id = question.Id;
            this.Content = question.Content;
            this.QuestionType = question.QuestionType;
            this.Test = new TestResponse(question.Test);
            this.DeletedAt = question.DeletedAt;
            this.CreatedAt = question.CreatedAt;
            this.LastUpdatedAt = question.LastUpdatedAt;
        }
    }
}
