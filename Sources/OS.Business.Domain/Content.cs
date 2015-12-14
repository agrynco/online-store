using System.Collections.Generic;

namespace OS.Business.Domain
{
    public class Content : NamedEntity
    {
        public ContentEnum Code { get; set; }
        public List<ContentContentType> ContentContentTypes { get; set; } 
    }
}