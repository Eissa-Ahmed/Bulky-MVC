namespace Bulky.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepo CategoryRepo { get; }
        IProductRepo ProductRepo { get; }
        void Save();
    }
}
