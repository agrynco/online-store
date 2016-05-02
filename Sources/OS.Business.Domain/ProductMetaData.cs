using System.ComponentModel.DataAnnotations;

namespace OS.Business.Domain
{
    public class ProductMetaData : IdentityEntity
    {
        public string Author { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}