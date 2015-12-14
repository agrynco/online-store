#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class Product : NamedEntity
    {
        public Product()
        {
            Categories = new List<ProductCategory>();
            Photos = new List<ProductPhoto>();
        }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public virtual List<ProductCategory> Categories { get; private set; }

        [Display(Name = "Бренд")]
        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }
        [Display(Name = "Країна-виробник")]
        public virtual Country CountryProducer { get; set; }

        [Display(Name = "Зображення")]
        public virtual List<ProductPhoto> Photos { get; set; }
    }
}