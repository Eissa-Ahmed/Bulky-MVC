using System.Linq.Expressions;

namespace Bulky.DAL.Repository.IRepository
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Remove(T model);
        void RemoveRange(IEnumerable<T> models);
        void Add(T model);

    }
}
