﻿#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AGrynCo.Lib;
using OS.Business.Domain;
using OS.Web.Models.ProductCategoryViewModels;
#endregion

namespace OS.Web.Models.ProductViewModels
{
    public class ProductPhotoViewModel : BaseClass
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

        public bool IsMain { get; set; }
    }

    public class ProductCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public ProductCreateOrEditViewModel(int? categoryId) : this()
        {
            CategorySelectorViewModel.Id = categoryId;
        }

        public ProductCreateOrEditViewModel()
        {
            PostedProductPhotos = new List<HttpPostedFileBase>();
            ProductPhotoViewModels = new List<ProductPhotoViewModel>();
            CategorySelectorViewModel = new ProductCategoryAutocompleteItem();
        }

        [Display(Name = "Назва товару")]
        [Required(ErrorMessage = "Поле {0} обов'язкове")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        public ProductCategoryAutocompleteItem CategorySelectorViewModel { get; set; }

        [Display(Name = "Зображення для завантаження")]
        public List<HttpPostedFileBase> PostedProductPhotos { get; set; }

        [Display(Name = "Бренд")]
        public string BrandName { get; set; }

        [Display(Name = "Країна-виробник")]
        public string CountryName { get; set; }

        [Display(Name = "Короткий опис")]
        [MaxLength(100)]
        [Required]
        public string ShortDescription { get; set; }

        [Display(Name = "Завантаженні зображення")]
        public List<ProductPhotoViewModel> ProductPhotoViewModels { get; set; }

        [Display(Name = "Ціна (грн.)")]
        [Required(ErrorMessage = "Поле {0} обов'язкове")]
        [RegularExpression(@"^(\d{1,})(\.\d{1,2})?$", ErrorMessage = "Невірний формат")]
        public string Price { get; set; }
    }
}