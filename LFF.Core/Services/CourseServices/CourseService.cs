using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.CourseServices
{
    public partial class CourseService : BaseService, ICourseService
    {
        private readonly IAggregateRepository aggregateRepository;

        public CourseService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
