using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    [Table("Photos")]
    public class Photo : File
    {
        public virtual File WaterMarked { get; set; }
    }

    [Table("ProductPhotos")]
    public class ProductPhoto : Photo
    {
        public bool IsMain { get; set; }
    }
}