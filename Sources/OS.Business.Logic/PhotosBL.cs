﻿using System.Drawing;
using System.IO;
using System.Web;
using OS.Business.Domain;
using OS.Configuration;
using OS.DAL.Abstract;
using File = OS.Business.Domain.File;

namespace OS.Business.Logic
{
    public class PhotosBL
    {
        private readonly ContentContentTypesBL _contentContentTypesBL;
        private readonly IPhotosRepository _photosRepository;

        private Photo ApplyWaterMark(Photo photo, string waterMarkText)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(photo.Data, 0, photo.Data.Length);
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

                    if (photo.WaterMarked == null)
                    {
                        photo.WaterMarked = new File();
                    }

                    photo.WaterMarked.ContentContentType = photo.ContentContentType;
                    photo.WaterMarked.Data = waterMarkedMemoryStream.ToArray();
                    photo.WaterMarked.FileName = photo.FileName;
                }
            }

            _photosRepository.Update(photo);

            return photo;
        }
        
        public PhotosBL(IPhotosRepository photosRepository, ContentContentTypesBL contentContentTypesBL)
        {
            _photosRepository = photosRepository;
            _contentContentTypesBL = contentContentTypesBL;
        }

        public Photo GetById(int id, string waterMarkText = null)
        {
            if (string.IsNullOrEmpty(waterMarkText))
            {
                waterMarkText = ApplicationSettings.Instance.AppSettings.ApplicationName;
            }

            Photo photo = _photosRepository.GetById(id);

            if (photo == null)
            {
                return null;
            }

            if (photo.WaterMarked == null)
            {
                photo = ApplyWaterMark(photo, waterMarkText);
            }

            return photo;
        }


        public Photo ApplyWaterMark(int id, string waterMarkText)
        {
            Photo photo = _photosRepository.GetById(id);

            ApplyWaterMark(photo, waterMarkText);

            return photo;
        }

        public Photo Update(Photo photo)
        {
            _photosRepository.Update(photo);
            return photo;
        }

        public Photo UpdateOrAdd(Photo photo, HttpPostedFileBase postedFile)
        {
            if (photo == null)
            {
                photo = new Photo();
            }

            byte[] buffer = new byte[postedFile.InputStream.Length];
            postedFile.InputStream.Read(buffer, 0, buffer.Length);
            photo.Data = buffer;
            photo.FileName = postedFile.FileName;
            photo.ContentContentType = _contentContentTypesBL.Get(postedFile.ContentType);

            if (photo.Id != 0)
            {
                _photosRepository.Update(photo);
            }
            else
            {
                photo = _photosRepository.Add(photo);
            }

            return photo;
        }
    }
}