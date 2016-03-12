namespace OS.Business.Logic.EmailTemplateProcessing
{
    public class EmailTemplateParameter<TValue> : IEmailTemplateParameter
    {
        public TValue Value { get; set; }
        public string Name { get; set; }
        object IEmailTemplateParameter.Value { get; set; }
    }
}