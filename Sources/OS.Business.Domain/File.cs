using System.ComponentModel.DataAnnotations;

namespace OS.Business.Domain
{
    public class File : IdentityEntity
    {
        [StringLength(255)]
        public string FileName { get; set; }
        
        public virtual ContentContentType ContentContentType { get; set; }

        public virtual byte[] Data { get; set; }
    }
}