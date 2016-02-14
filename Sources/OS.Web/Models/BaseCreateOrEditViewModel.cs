using AGrynCo.Lib;

namespace OS.Web.Models
{
    public abstract class BaseCreateOrEditViewModel : BaseClass
    {
         public virtual int? Id { get; set; }
    }
}