using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class HomePageViewModel : HorizontalCategorySelectorViewModel
    {
        public IList<Product> Products { get; set; }

        public PaginationFilterViewModel PaginationFilterViewModel { get; set; }
    }
}