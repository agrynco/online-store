namespace OS.Business.Domain
{
    public class EmailTemplate : IdentityEntity
    {
        public TemplateType TemplateType { get; set; }
        public string Text { get; set; }
    }
}