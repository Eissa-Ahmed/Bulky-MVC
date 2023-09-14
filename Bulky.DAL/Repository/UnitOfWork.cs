using Bulky.DAL.Database;
using Bulky.DAL.Repository.IRepository;

namespace Bulky.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public ICategoryRepo CategoryRepo { get; private set; }

        public IProductRepo ProductRepo { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            CategoryRepo = new CategoryRepo(dbContext);
            ProductRepo = new ProductRepo(dbContext);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
