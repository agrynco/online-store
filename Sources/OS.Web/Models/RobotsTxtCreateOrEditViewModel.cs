using System.ComponentModel.DataAnnotations;

namespace OS.Web.Models
{
    public class RobotsTxtCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}