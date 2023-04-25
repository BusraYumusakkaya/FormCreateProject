using System.Linq.Expressions;

namespace FormCreateProject.Repositories.Abstract
{
    public interface IRepository<T> where T : class //jeneric repository
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}
