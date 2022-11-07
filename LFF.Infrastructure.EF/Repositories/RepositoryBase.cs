using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.Repositories;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity<Guid?>, ICreationEntity, IModificationEntity, IDeletionEntity
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public RepositoryBase(IDbContextFactory<AppDbContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                entity.CreatedAt = entity.LastUpdatedAt = DateTime.Now;
                entity.DeletedAt = null;
                await dbs.Set<T>().AddAsync(entity);
                await dbs.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                entity.LastUpdatedAt = DateTime.Now;
                dbs.Set<T>().Update(entity);
                await dbs.SaveChangesAsync();
                return entity;
            }
        }

        protected virtual async Task<T> BaseGetAsync(Expression<Func<T, bool>> expression)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var model = await dbs.Set<T>().Where(u => u.DeletedAt == null).FirstOrDefaultAsync(expression);
                return model;
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                var model = await this.BaseGetAsync(u => u.Id == id);
                return model;
            }
        }

        protected virtual async Task<bool> BaseAnyAsync(Expression<Func<T, bool>> expression)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var result = await dbs.Set<T>().Where(u => u.DeletedAt == null).AnyAsync(expression);
                return result;
            }
        }

        protected async Task<IEnumerable<T>> BaseListAsync(Expression<Func<T, bool>> expression)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var models = await dbs.Set<T>().Where(u => u.DeletedAt == null).Where(expression).ToListAsync();
                return models;
            }
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var models = await dbs.Set<T>().Where(u => u.DeletedAt == null).ToListAsync();
                return models;
            }
        }

        public virtual async Task<IEnumerable<T>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var models = await dbs.Set<T>().Where(u => u.DeletedAt == null).ToListAsync();
                return models;
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                entity.DeletedAt = DateTime.Now;
                dbs.Set<T>().Update(entity);
                await dbs.SaveChangesAsync();
                return true;
            }
        }
    }
}
