using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using LFF.Core.Repositories;
using LFF.Infrastructure.EF.DataAccess;
using LFF.Infrastructure.EF.Utils.PasswordUtils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;
        private readonly PasswordHasherManaged passwordHasherManaged;

        public UserRepository(IDbContextFactory<AppDbContext> dbFactory, PasswordHasherManaged passwordHasherManaged)
            : base(dbFactory)
        {
            this.dbFactory = dbFactory;
            this.passwordHasherManaged = passwordHasherManaged;
        }

        public override Task<User> CreateAsync(User entity)
        {
            entity.Password = this.passwordHasherManaged.GetHashedPassword(entity.Password);
            return base.CreateAsync(entity);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Username == username);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Email == email);
            }
        }

        public async Task<User> GetUserByCMNDAsync(string cMND)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.CMND == cMND);
            }
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var user = await dbs.Users.Where(u => u.DeletedAt == null).FirstOrDefaultAsync(u => u.Username == username);
                
                if (user is null)
                    return null;

                if (this.passwordHasherManaged.CheckPassword(password, user.Password))
                {
                    user.Password = null;
                    return user;
                }

                return null;
            }
        }

        public async Task<bool> CheckUserExistedByIdAsync(Guid id)
        {
            await using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckUserExistedByUsernameAsync(string username)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Username == username);
            }
        }

        public async Task<bool> CheckUserExistedByUsernameExceptIdAsync(Guid id, string username)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Username == username && u.Id != id);
            }
        }

        public async Task<bool> CheckUserExistedByEmailAsync(string email)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Email == email);
            }
        }

        public async Task<bool> CheckUserExistedByEmailExceptIdAsync(Guid id, string email)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Email == email && u.Id != id);
            }
        }

        public async Task<bool> CheckUserExistedByCMNDAsync(string cMND)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.CMND == cMND);
            }
        }

        public async Task<bool> CheckUserExistedByCMNDExceptIdAsync(Guid id, string cMND)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.CMND == cMND && u.Id != id);
            }
        }

        public override async Task<IEnumerable<User>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<User>().Select(u => u).Where(u => u.DeletedAt == null);
                foreach (var q in queries)
                {
                    var tokens = q.Name.ToLower().Split(".");
                    if (tokens.Length < 2 || q.Values.Count == 0)
                        throw new ArgumentException($"Tham số không hợp lệ '{q.Name}'");
                    if (tokens[0] == "username")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Username.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Username.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Username.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Username == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "password")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Password.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Password.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Password.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Password == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "fullname")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.FullName.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.FullName.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.FullName.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.FullName == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "email")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Email.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Email.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Email.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Email == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "dateofbirth")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.DateOfBirth >= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.DateOfBirth <= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.DateOfBirth == DateTime.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "cmnd")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.CMND.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.CMND.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.CMND.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.CMND == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "role")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Role.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Role.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Role.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Role == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }
                return await query.ToListAsync();
            }
        }

        public async Task UpdatePasswordByIdAsync(Guid userId, string? password)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var userEntity = dbs.Users.FirstOrDefault(u => u.Id == userId);
                userEntity.Password = this.passwordHasherManaged.GetHashedPassword(password);
                await dbs.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByIdAndPassword(Guid userId, string password)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var user = await dbs.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user is null)
                    return null;

                if (this.passwordHasherManaged.CheckPassword(password, user.Password))
                {
                    user.Password = null;
                    return user;
                }

                return null;
            }
        }
    }
}
