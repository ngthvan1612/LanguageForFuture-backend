using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.QuestionServices
{
    public partial class QuestionService : BaseService, IQuestionService
    {
        private readonly IAggregateRepository aggregateRepository;

        public QuestionService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
