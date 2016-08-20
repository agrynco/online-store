using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductPhotosBL
    {
        private readonly IProductPhotosRepository _productPhotosRepository;

        public ProductPhotosBL(IProductPhotosRepository productPhotosRepository)
        {
            _productPhotosRepository = productPhotosRepository;
        }

        public void Delete(params int[] id)
        {
            _productPhotosRepository.Delete(id);
        }
    }
}