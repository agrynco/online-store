namespace OS.Business.Domain
{
    public class TextContent : IdentityEntity
    {
        public string Text { get; set; }
        public TextContentCode Code { get; set; }
    }
}