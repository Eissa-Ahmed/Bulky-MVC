using Bulky.Model.Models;

namespace Bulky.DAL.Repository.IRepository
{
    public interface IProductRepo : IRepo<Prouduct>
    {
        void Update(Prouduct prouduct);
    }
}
