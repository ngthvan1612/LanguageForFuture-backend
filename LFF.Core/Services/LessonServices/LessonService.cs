using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.LessonServices
{
    public partial class LessonService : BaseService, ILessonService
    {
        private readonly IAggregateRepository aggregateRepository;

        public LessonService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
