using System;
using AGrynCo.Lib.Collections;

namespace OS.Business.Logic.EmailTemplateProcessing
{
    public class EmailTemplateParameterList : CustomCollection<string, IEmailTemplateParameter>
    {
        public void Add(IEmailTemplateParameter emailTemplateParameter)
        {
            ((ICustomCollection) this).Add(emailTemplateParameter.Name, emailTemplateParameter);
        } 
    }
}