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
        public string CodeISO { get; set; }

        public List<Country> Countries { get; set; }

        [Display(Name = "Використовуэться в країні")]
        public int? CountryId { get; set; }

        public string HexSymbol { get; set; }

        [Display(Name = "Головна")]
        public bool IsMain { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Символ")]
        public string Symbol { get; set; }
    }
}