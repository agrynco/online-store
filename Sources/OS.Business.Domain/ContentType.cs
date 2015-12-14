using System.Collections.Generic;

namespace OS.Business.Domain
{
    public class ContentType : NamedEntity
    {
        public ContentTypeEnum Code { get; set; }
        public List<ContentContentType> ContentContentTypes { get; set; }
    }
}