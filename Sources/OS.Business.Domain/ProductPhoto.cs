using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    [Table("ProductPhotos")]
    public class ProductPhoto : Photo
    {
        public bool IsMain { get; set; }
    }
}