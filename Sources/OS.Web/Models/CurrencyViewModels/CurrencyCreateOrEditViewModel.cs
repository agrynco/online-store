using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OS.Business.Domain;

namespace OS.Web.Models.CurrencyViewModels
{
    public class CurrencyCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        [Display(Name = "Банківський код")]
        public int Code { get; set; }

        [Display(Name = "Код ISO")]
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        public string CodeISO { get; set; }

        public List<Country> Countries { get; set; }

        [Display(Name = "Використовуэться в країні")]
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        public int? CountryId { get; set; }

        [Display(Name = "Шістнадцятковий код")]
        public string HexSymbol { get; set; }

        [Display(Name = "Головна")]
        public bool IsMain { get; set; }

        [Display(Name = "Назва")]
        [MaxLength(150, ErrorMessage = "Кількість символів в полі Назва має бути не більше 150 символів")]
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        public string Name { get; set; }

        [Display(Name = "Символ")]
        [MaxLength(5, ErrorMessage = "Кількість символів в полі Символ має бути не більше 5 символів")]
        [Required(ErrorMessage = Constants.ValidationMessages.REQUIRED)]
        public string Symbol { get; set; }
    }
}