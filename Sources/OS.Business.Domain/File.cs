using System.ComponentModel.DataAnnotations;

namespace OS.Business.Domain
{
    public abstract class File : IdentityEntity
    {
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}