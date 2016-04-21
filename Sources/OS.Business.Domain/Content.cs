using System.Collections.Generic;

namespace OS.Business.Domain
{
    /// <summary>
    /// MIME content. UFor uploaded files
    /// </summary>
    public class Content : NamedEntity
    {
        public ContentEnum Code { get; set; }
        public List<ContentContentType> ContentContentTypes { get; set; } 
    }
}