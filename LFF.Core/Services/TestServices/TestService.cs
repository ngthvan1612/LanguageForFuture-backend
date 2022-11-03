using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.TestServices
{
    public partial class TestService : BaseService, ITestService
    {
        private readonly IAggregateRepository aggregateRepository;

        public TestService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
