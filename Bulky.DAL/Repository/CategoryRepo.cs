using Bulky.BL.Models;
using Bulky.DAL.Database;
using Bulky.DAL.Repository.IRepository;

namespace Bulky.DAL.Repository
{
    public class CategoryRepo : Repo<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepo(ApplicationDbContext dbContext) : base(dbContext) {
           this.dbContext = dbContext;
        }


        public void Update(Category model)
        {
            dbContext.Categories.Update(model);
        }
    }
}
