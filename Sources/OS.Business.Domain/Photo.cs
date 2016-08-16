using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    [Table("Photos")]
    public class Photo : File
    {
        public virtual File WaterMarked { get; set; }
    }
}