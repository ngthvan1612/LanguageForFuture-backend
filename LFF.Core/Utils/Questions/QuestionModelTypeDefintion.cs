using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LFF.Core.Utils.Questions
{
    public class QuestionModelTypeDefintion
    {
        /// <summary>
        /// Câu hỏi nhiều đáp án chọn 1
        /// </summary>
        public static readonly string QUESTION_TYPE_MULTIPLE_CHOICE = "MULTIPLE-CHOICE";

        public static readonly JsonSerializerSettings NewtonsoftSerlizerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
