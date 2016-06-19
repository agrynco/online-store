using System.Drawing;
using System.IO;
using OS.Business.Domain;
using OS.Configuration;
using OS.DAL.Abstract;
using File = OS.Business.Domain.File;

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

        public ProductPhoto GetById(int id, string waterMarkText = null)
        {
            if (string.IsNullOrEmpty(waterMarkText))
            {
                waterMarkText = ApplicationSettings.Instance.AppSettings.ApplicationName;
            }

            ProductPhoto productPhoto = _productPhotosRepository.GetById(id);
            if (productPhoto.WaterMarked == null)
            {
                productPhoto = ApplyWaterMark(productPhoto, waterMarkText);
            }

            return productPhoto;
        }

        private ProductPhoto ApplyWaterMark(ProductPhoto productPhoto, string waterMarkText)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(productPhoto.Data, 0, productPhoto.Data.Length);
                memoryStream.Position = 0;

                Bitmap sourceImage = (Bitmap) Image.FromStream(memoryStream);

                using (Font font = new Font("Arial", 14, FontStyle.Bold))
                {
                    using (Graphics destination = Graphics.FromImage(sourceImage))
                    {
                        float width = sourceImage.Width / 2f;
                        float height = sourceImage.Height / 2f;

                        destination.TranslateTransform(width, height);
                        destination.RotateTransform(45);

                        SizeF size = destination.MeasureString(waterMarkText, font);
                        PointF drawPoint = new PointF(-size.Width / 2f, -size.Height / 2f);
                        destination.DrawString(waterMarkText, font, Brushes.LawnGreen, drawPoint);
                    }
                }

                using (MemoryStream waterMarkedMemoryStream = new MemoryStream())
                {
                    sourceImage.Save(waterMarkedMemoryStream, sourceImage.RawFormat);

                    if (productPhoto.WaterMarked == null)
                    {
                        productPhoto.WaterMarked = new File();
                    }

                    productPhoto.WaterMarked.ContentContentType = productPhoto.ContentContentType;
                    productPhoto.WaterMarked.Data = waterMarkedMemoryStream.ToArray();
                    productPhoto.WaterMarked.FileName = productPhoto.FileName;
                }
            }

            _productPhotosRepository.Update(productPhoto);

            return productPhoto;
        }

        public ProductPhoto ApplyWaterMark(int id, string waterMarkText)
        {
            ProductPhoto productPhoto = _productPhotosRepository.GetById(id);

            ApplyWaterMark(productPhoto, waterMarkText);

            return productPhoto;
        }
    }
}