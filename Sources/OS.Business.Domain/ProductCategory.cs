#region Usings
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class ProductCategory : NamedEntity
    {
        public virtual ProductCategory Parent { get; set; }

        public int? ParentId { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public virtual List<ProductCategory> ChildCategories { get; set; } 
    }
}