using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetQuestionByIdAsync(Guid id);
        Task<bool> CheckQuestionExistedByIdAsync(Guid id);
    }
}
