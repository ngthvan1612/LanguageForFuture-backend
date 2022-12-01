using LFF.Core.Base;
using LFF.Core.DTOs.Tests.Requests;
using LFF.Core.Repositories;
using System.Threading.Tasks;

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
