#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class ProductCategory : NamedPublishedEntity
    {
        public ProductCategory()
        {
            ChildCategories = new List<ProductCategory>();
            Products = new List<Product>();
        }

        public virtual List<ProductCategory> ChildCategories { get; private set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public int Order { get; set; }

        public virtual ProductCategory Parent { get; set; }

        public int? ParentId { get; set; }

        public virtual List<Product> Products { get; private set; }

        public virtual string Article { get; set; }
    }
}