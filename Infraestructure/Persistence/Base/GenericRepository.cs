using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected MedicalCenterDbContext _db;
        protected readonly DbSet<T> _dbset;

        public GenericRepository(MedicalCenterDbContext context)
        {
            _db = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public virtual T Find(object id)
        {
            return _dbset.Find(id);
        }

        protected IQueryable<T> FindByAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        protected IQueryable<T> AsQueryable()
        {
            return _dbset.AsQueryable();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            Commit();
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
            Commit();
        }
        public virtual void Edit(T entity)
        {
            _db.SetModified(entity);
            Commit();
        }
        public virtual void DeleteRange(List<T> entities)
        {
            _dbset.RemoveRange(entities);
            Commit();
        }
        public virtual void AddRange(List<T> entities)
        {
            _dbset.AddRange(entities);
            Commit();
        }

        public T? FindFirstOrDefault(Expression<Func<T, bool>> predicate, string includeProperties = "")
        {
            T query = _dbset.FirstOrDefault(predicate);
            return query;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
