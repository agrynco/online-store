namespace OS.DAL.Abstract
{
    public interface IOnlineStoreDbContext
    {
        IProductCategoriesRepository CategoriesRepository { get; }
        IProductsRepository ProductsRepository { get; }
        int SaveChanges();
    }
}