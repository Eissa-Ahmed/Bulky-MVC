using Bulky.BL.Models;

namespace Bulky.DAL.Repository.IRepository
{
    public interface ICategoryRepo : IRepo<Category>
    {
        void Update(Category model);
    }
}
 