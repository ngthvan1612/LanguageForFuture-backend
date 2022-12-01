using LFF.Core.Base;
using LFF.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestServices
{
    public partial class StudentTestService : BaseService, IStudentTestService
    {
        private readonly IAggregateRepository aggregateRepository;

        public StudentTestService(IAggregateRepository aggregateRepository)
        {
            this.aggregateRepository = aggregateRepository;
        }

        public async Task<ResponseBase> SubmitAsync(Guid id)
        {
            if (await this.aggregateRepository.StudentTestRepository.CheckStudentTestExistedByIdAsync(id) == false)
                throw BaseDomainException.BadRequest($"Không tồn tại bất kì bài thi nào có id = {Id}");

            await this.aggregateRepository.StudentTestRepository.SubmitTestAsync(id);

            return SuccessResponseBase.Send("Nộp bài kiểm tra thành công");
        }
    }
}
