using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByCMNDAsync(string cMND);
        Task<User> GetUserByUsernameAndPassword(string username, string password);
        Task<bool> CheckUserExistedByIdAsync(Guid id);
        Task<bool> CheckUserExistedByUsernameAsync(string username);
        Task<bool> CheckUserExistedByUsernameExceptIdAsync(Guid id, string username);
        Task<bool> CheckUserExistedByEmailAsync(string email);
        Task<bool> CheckUserExistedByEmailExceptIdAsync(Guid id, string email);
        Task<bool> CheckUserExistedByCMNDAsync(string cMND);
        Task<bool> CheckUserExistedByCMNDExceptIdAsync(Guid id, string cMND);
        Task UpdatePasswordByIdAsync(Guid userId, string? password);
    }
}
