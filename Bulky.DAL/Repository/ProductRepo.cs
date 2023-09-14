using Bulky.DAL.Database;
using Bulky.DAL.Repository.IRepository;
using Bulky.Model.Models;

namespace Bulky.DAL.Repository
{
    public class ProductRepo : Repo<Prouduct>, IProductRepo
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepo(ApplicationDbContext dbContext) : base(dbContext) 
        { 
            this.dbContext = dbContext; 
        }


        public void Update(Prouduct prouduct)
        {
            dbContext.Prouducts.Update(prouduct);
        }
    }
}
