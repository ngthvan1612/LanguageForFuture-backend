using LFF.Core.Base;
using LFF.Core.Repositories;

namespace LFF.Core.Services.StudentTestResultServices
{
    public partial class StudentTestResultService : BaseService, IStudentTestResultService
    {
        private readonly IAggregateRepository aggregateRepository;

        public StudentTestResultService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }
    }
}
