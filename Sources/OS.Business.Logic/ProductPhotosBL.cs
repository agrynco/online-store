using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class ProductPhotosBL
    {
        private readonly PhotosBL _photosBL;
        private readonly IProductPhotosRepository _productPhotosRepository;

        public ProductPhotosBL(PhotosBL photosBL, IProductPhotosRepository productPhotosRepository)
        {
            _photosBL = photosBL;
            _productPhotosRepository = productPhotosRepository;
        }

        public void Delete(params int[] id)
        {
            _productPhotosRepository.Delete(id);
        }
    }
}