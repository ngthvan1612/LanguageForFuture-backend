using LFF.Core.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFF.Core.Utils.Questions
{
    public class MultipleChoiceResponse : ICloneable
    {
        public MultipleChoiceResponse(string raw = "", string code = "")
        {
            Raw = raw;
            Code = code;
        }

        /// <summary>
        /// Nội dung hiển thị lên view
        /// </summary>
        public string Raw { get; set; }

        /// <summary>
        /// Mã lựa chọn: A, B, C, D, E...
        /// </summary>
        public string Code { get; set; }

        public object Clone()
        {
            return new MultipleChoiceResponse(this.Raw, this.Code);
        }
    }

    public class MultipleChoiceQuestionContent : ICloneable
    {
        public MultipleChoiceQuestionContent(string raw = "")
        {
            Raw = raw;
        }

        /// <summary>
        /// Nội dung câu hỏi hiển thị trên view
        /// </summary>
        public string Raw { get; set; }

        public object Clone()
        {
            return new MultipleChoiceQuestionContent("");
        }
    }

    public class MultipleChoiceQuestion : QuestionModelAbstract
    {
        /// <summary>
        /// Danh sách lựa chọn
        /// </summary>
        public List<MultipleChoiceResponse> Choices { get; set; } = new List<MultipleChoiceResponse>();

        /// <summary>
        /// Nội dung câu hỏi
        /// </summary>
        public MultipleChoiceQuestionContent Question { get; set; }

        /// <summary>
        /// Đáp án
        /// </summary>
        public string? Answer { get; set; }

        public MultipleChoiceQuestion()
            : base()
        {
            this.Question = new MultipleChoiceQuestionContent();
            this.Answer = null;
            this.Meta.Type = QuestionModelTypeDefintion.QUESTION_TYPE_MULTIPLE_CHOICE;
        }

        /// <summary>
        /// Chế độ xem (truyền cho học viên): xóa bỏ các trường liên quan đến kết quả
        /// </summary>
        /// <returns></returns>
        public MultipleChoiceQuestion AsView()
        {
            var question = new MultipleChoiceQuestion()
            {
                Question = (MultipleChoiceQuestionContent)this.Question.Clone(),
                Answer = this.Answer,
            };
            return question;
        }

        public override object Clone()
        {
            return new MultipleChoiceQuestion()
            {
                Meta = (QuestionModelBaseMeta)this.Meta.Clone(),
                Question = (MultipleChoiceQuestionContent)this.Question.Clone(),
                Choices = this.Choices.Select(u => (MultipleChoiceResponse)u.Clone()).ToList()
            };
        }

        protected override void ValidateFields()
        {
            base.ValidateFields();

            if (this.Question.Raw.Trim().Length == 0)
                throw BaseDomainException.BadRequest($"Nội dung câu hỏi không được trống");

            if (this.Choices.GroupBy(u => u.Code.Trim()).Count() != this.Choices.Count)
                throw BaseDomainException.BadRequest($"Không được phép có 2 câu hỏi chung một mã trả lời (A, B, C..)");

            var temp = this.Choices.FirstOrDefault(u => string.IsNullOrEmpty(u.Raw) || u.Raw.Trim().Length == 0);
            if (temp != null)
                throw BaseDomainException.BadRequest($"Vui lòng thêm nội dung cho lựa chọn {temp.Code}");

            if (this.Choices.Count < 2)
                throw BaseDomainException.BadRequest($"Phải có ít nhất 2 lựa chọn");

            if (string.IsNullOrEmpty(this.Answer))
                throw BaseDomainException.BadRequest($"Đáp án không được trống");

            if (!this.Choices.Any(u => u.Code == this.Answer))
                throw BaseDomainException.BadRequest($"Không tìm thấy đáp án với mã {this.Answer} trong danh sách lựa chọn");
        }

        public override bool CheckAnswer(object? answer)
        {
            if (!(answer is string))
                return false;
            return this.Answer == answer.ToString();
        }

        public override int CalculateScore(object? answer)
        {
            if (!(answer is string))
                return 0;
            if (this.Answer == answer.ToString())
                return 1;
            return 0;
        }

        public override bool CheckAnswerIsValid(object? answer)
        {
            if (!(answer is string))
                return false;
            return this.Choices.Any(u => u.Code == answer.ToString());
        }
    }
}
