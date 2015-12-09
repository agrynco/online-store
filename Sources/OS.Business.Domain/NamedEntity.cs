#region Usings
using System.ComponentModel.DataAnnotations;
#endregion

namespace OS.Business.Domain
{
    public class NamedEntity : IdentityEntity
    {
        [Required(ErrorMessage = "Поле Назва обов'язкове")]
        [MaxLength(250, ErrorMessage = "Кількість символів в полі Назва має бути не більше 250 символів")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
    }
}