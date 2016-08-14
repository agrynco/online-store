using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    [Table("Photos")]
    public class Photo : File
    {
        public bool IsMain { get; set; }

        public virtual File WaterMarked { get; set; }
    }
}