using OS.Business.Domain;

namespace OS.DAL.Abstract
{
    public interface IProductViewingInfosRepository : IOnlineStoreRepository<ProductViewingInfo>
    {
        ProductViewingInfo Get(int productId, int userHostAddressId);
    }
}