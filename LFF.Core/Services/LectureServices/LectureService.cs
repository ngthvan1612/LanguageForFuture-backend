using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.LectureServices
{
    public partial class LectureService : BaseService, ILectureService
    {
        private readonly IAggregateRepository aggregateRepository;

        public LectureService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
