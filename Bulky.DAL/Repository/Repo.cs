using Bulky.DAL.Database;
using Bulky.DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DAL.Repository
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        internal DbSet<T> dbSet;
        public Repo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public void Add(T model)
        {
            dbSet.Add(model);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var item = dbSet.Where(filter).FirstOrDefault();
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            var items = dbSet.ToList();
            return items;
        }

        public void Remove(T model)
        {
            dbSet.Remove(model);
        }

        public void RemoveRange(IEnumerable<T> models)
        {
            dbSet.RemoveRange(models);
        }
    }
}
