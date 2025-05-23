using LinkDev.IKEA.DAL.Common.Entities;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Persistance.Common;
using LinkDev.IKEA.DAL.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Contracts.Repositories
{
    public interface IBaseRepository<TEntity,TKey> where TEntity :BaseEntity<TKey>
        where TKey:IEquatable<TKey>
    {
        public TEntity? Get(int id);
        public TEntity? Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
        public IEnumerable<TEntity> GetAll(bool WithTracking = false);
        public PaginatedResult<TEntity>GetAll(QueryParameters Parameters, Expression<Func<TEntity, bool>>? filter=null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderby = null, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
        public void Add(TEntity Entity);
        public void Delete(int id);
        public void Update(TEntity Entity);
        public bool Exist(Expression<Func<TEntity, bool>> filter);


    }
}
