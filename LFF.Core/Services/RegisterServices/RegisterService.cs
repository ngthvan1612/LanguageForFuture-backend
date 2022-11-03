using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.RegisterServices
{
    public partial class RegisterService : BaseService, IRegisterService
    {
        private readonly IAggregateRepository aggregateRepository;

        public RegisterService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
