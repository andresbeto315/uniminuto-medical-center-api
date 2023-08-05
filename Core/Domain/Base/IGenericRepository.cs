using System.Linq.Expressions;

namespace Domain.Base
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Find(object id);
        void Add(T entity);
        void Delete(T entity);
        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);
        IEnumerable<T> GetAll();
        T FindFirstOrDefault(Expression<Func<T, bool>> predicate, string includeProperties = "");
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    }
}