using LFF.Core.Base;
using Newtonsoft.Json;
using System;

namespace LFF.Core.Utils.Questions
{
    public static class QuestionModelFactory
    {
        public static QuestionModelAbstract FromJsonString(string jsonStr)
        {
            dynamic? json = null;

            try
            {
                json = JsonConvert.DeserializeObject<dynamic>(jsonStr);
            }
            catch (Exception e)
            {
                throw BaseDomainException.BadRequest($"Không thể đọc được JSON", e.Message);
            }

            if (json is null || json.meta is null || json.meta.type is null)
                throw BaseDomainException.BadRequest($"Định dạng JSON không hợp lệ");

            json.meta.type = json.meta.type.ToString();

            if (json.meta.type.ToString() == QuestionModelTypeDefintion.QUESTION_TYPE_MULTIPLE_CHOICE)
            {
                var instance = JsonConvert.DeserializeObject<MultipleChoiceQuestion>(jsonStr);

                instance.RunValidation();

                return instance;
            }
            else throw BaseDomainException.BadRequest($"Không tìm thấy mã định danh câu hỏi <'{json.meta.type.ToString()}'>");
        }

        public static string ToJsonString(QuestionModelAbstract question)
        {
            return question.ToJsonString();
        }
    }
}
