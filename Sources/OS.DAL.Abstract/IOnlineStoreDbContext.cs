namespace OS.DAL.Abstract
{
    public interface IOnlineStoreDbContext
    {
        IProductCategoriesRepository CategoriesRepository { get; }

        int SaveChanges();
    }
}