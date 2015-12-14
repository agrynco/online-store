using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.Business.Domain
{
    public class ContentContentType : IdentityEntity
    {
        public int ContentTypeId { get; set; }

        public int ContentId { get; set; }

        public virtual ContentType ContentType { get; set; }
        public virtual Content Content { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Content.Name, ContentType.Name);
        }
    }
}