namespace OS.Business.Logic.EmailTemplateProcessing
{
    public interface IEmailTemplateParameter
    {
        string Name { get; set; }
        object Value { get; set; }
    }
}