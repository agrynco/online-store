namespace OS.Business.Domain
{
    public class HtmlContent : IdentityEntity
    {
        public string Text { get; set; }
        public HtmlContentCode Code { get; set; }
    }
}