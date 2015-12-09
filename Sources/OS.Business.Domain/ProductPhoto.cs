using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    [Table("ProductPhotos")]
    public class ProductPhoto : File
    {
        public bool IsMain { get; set; }
    }
}