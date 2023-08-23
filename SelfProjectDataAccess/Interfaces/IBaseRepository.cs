using System.Linq.Expressions;

namespace SelfProjectDataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllInclude(params string[] includeProps);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetInclude(Expression<Func<T, bool>> filter, params string[] includeProps);
        T FirstOrDefault(Expression<Func<T, bool>> filter);
        T FirstOrDefaultInclude(Expression<Func<T, bool>> filter, params string[] includeProps);
        int Add(T entity);
        int Delete(params object[] key);
        int Delete(T entity);
        T Find(params object[] key);
        void Detach(T entity);
        int Update(T entity);
    }
}
