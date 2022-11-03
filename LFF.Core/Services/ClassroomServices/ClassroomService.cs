using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.ClassroomServices
{
    public partial class ClassroomService : BaseService, IClassroomService
    {
        private readonly IAggregateRepository aggregateRepository;

        public ClassroomService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
