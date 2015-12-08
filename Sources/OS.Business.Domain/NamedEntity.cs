#region Usings
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class NamedEntity : IdentityEntity
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Кількість символів в полі Назва має бути не більше 250 символів")]
        [Display(Name = "Назва")]
        public virtual string Name { get; set; }
    }
}