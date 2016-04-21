using OS.Business.Domain;

namespace OS.Web.Models.HtmlContentViewModels
{
    public class HtmlContentCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public string Text { get; set; }
        public HtmlContentCode Code { get; set; }
    }
}