#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using OS.Business.Domain;
#endregion

namespace OS.Web.Models.ProductViewModels
{
    public class ProductPhotoViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// <see cref="File.FileName"/>
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Defines is photo deleted during editing the <see cref="Product"/>
        /// </summary>
        public bool IsDeleted { get; set; }
    }

    public class ProductCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public ProductCreateOrEditViewModel()
        {
            PostedProductPhotos = new List<HttpPostedFileBase>();
            ProductPhotoViewModels = new List<ProductPhotoViewModel>();
        }

        [Display(Name = "Назва товару")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        public string Description { get; set; }

        public int? OwnerCategoryId { get; set; }

        [Display(Name = "Зображення для завантаження")]
        public List<HttpPostedFileBase> PostedProductPhotos { get; set; }

        [Display(Name = "Бренд")]
        public string BrandName { get; set; }

        [Display(Name = "Країна-виробник")]
        public string CountryName { get; set; }

        [Display(Name = "Завантаженні зображення")]
        public List<ProductPhotoViewModel> ProductPhotoViewModels { get; set; }
    }
}