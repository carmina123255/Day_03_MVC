using LinkDev.IKEA.DAL.Common.Entities;
using LinkDev.IKEA.DAL.Contracts.Repositories;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Persistance.Common;
using LinkDev.IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Repositories
{
    public  class BaseRepository<TEntity,TKey>:IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey:IEquatable<TKey>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            dbContext = context;
            _dbSet = dbContext.Set<TEntity>();
        }
        public TEntity? Get(int id)
          => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
        {
            if (!WithTracking)
                return _dbSet.AsNoTracking().ToList();
            return _dbSet.ToList();
        }
        public void Add(TEntity Entity)
        => _dbSet.Add(Entity);

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity is { }) _dbSet.Remove(entity);
        }

        public void Update(TEntity Entity)
       => _dbSet.Update(Entity);

        public TEntity? Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes is not null)
                query = includes(query);

            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public PaginatedResult<TEntity> GetAll(QueryParameters Parameters ,Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes is not null)
                query = includes(query);

            query = query.Where(filter);
            var totalCount = query.Count();
           if(orderby is not  null)
            {
                query = orderby(query);

            }
           //Apply Pagination 
            var entities = query
                .Skip(Parameters.PageSize*(Parameters.PageIndex-1))
                .Take(Parameters.PageSize)
                .ToList();
            return new PaginatedResult<TEntity>()
            {
                Data = entities,
                TotalCount = totalCount,
                PageIndex = Parameters.PageIndex,
                PageSize = Parameters.PageSize,

            };
        }

        public bool Exist(Expression<Func<TEntity, bool>> filter)
        => _dbSet.Any(filter);
    }
}
