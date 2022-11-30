using System;
using System.Collections.Generic;
using System.Linq;
using LFF.Core.Base;
using Newtonsoft.Json;

namespace LFF.Core.Utils.Questions
{
    public class QuestionModelBaseMeta : ICloneable
    {
        /// <summary>
        /// Version câu hỏi (không phải version của nội dung) mà là version của trình xử lý câu hỏi
        /// </summary>
        public int Version { get; set; } = 0;

        /// <summary>
        /// Loại câu hỏi
        /// </summary>
        public string Type { get; set; } = "<Unknown type>";

        public object Clone()
        {
            return new QuestionModelBaseMeta()
            {
                Version = this.Version,
                Type = this.Type
            };
        }
    }

    public abstract class QuestionModelAbstract : ICloneable
    {
        public QuestionModelBaseMeta Meta { get; set; }
        public List<string> Solutions { get; set; }

        public QuestionModelAbstract()
        {
            this.Meta = new QuestionModelBaseMeta();
            this.Solutions = new List<string>();
            this.Meta.Version = 1;
        }

        public virtual string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, QuestionModelTypeDefintion.NewtonsoftSerlizerSettings);
        }

        public void RunValidation()
        {
            this.ValidateFields();
        }

        public bool RunValidationWithoutThrowException(ref string error_message)
        {
            try
            {
                this.ValidateFields();
                return true;
            }
            catch (Exception e)
            {
                error_message = e.Message;
                return false;
            }
        }

        protected virtual void ValidateFields()
        {
            if (!new string[] { QuestionModelTypeDefintion.QUESTION_TYPE_MULTIPLE_CHOICE }.Contains(this.Meta.Type))
                throw BaseDomainException.BadRequest($"Không rõ mã định danh câu hỏi <'{this.Meta.Type}'>");
        }

        public abstract QuestionModelAbstract AsView();

        public abstract bool CheckAnswerIsValid(object? answer);

        public abstract bool CheckAnswer(object? answer);

        public abstract int CalculateScore(object? answer);

        public abstract object Clone();
    }
}
