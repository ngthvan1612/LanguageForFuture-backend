using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.StudentTestServices
{
    public partial class StudentTestService : BaseService, IStudentTestService
    {
        private readonly IAggregateRepository aggregateRepository;

        public StudentTestService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
