#region Usings
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class ProductCategory : NamedEntity
    {
        public virtual ProductCategory Parent { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }
    }
}