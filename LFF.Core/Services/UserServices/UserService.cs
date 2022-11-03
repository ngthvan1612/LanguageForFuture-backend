using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.UserServices
{
    public partial class UserService : BaseService, IUserService
    {
        private readonly IAggregateRepository aggregateRepository;

        public UserService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
