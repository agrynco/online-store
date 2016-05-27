using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OS.Business.Domain;

namespace OS.Web.Models.CurrencyRateViewModels
{
    public class CurrencyRateCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public List<Currency> Currencies { get; set; }

        [Required]
        public int? CurrencyId { get; set; }

        public Currency MainCurrency { get; set; }

        public decimal Rate { get; set; }
    }
}