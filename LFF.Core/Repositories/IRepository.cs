using LFF.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries);
        Task<int> NumberOfTimesAttemptTest(Guid studentId, Guid testId);
    }
}
