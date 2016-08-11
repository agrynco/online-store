using System.Collections.Generic;
using OS.Business.Domain;

namespace OS.Web.Models
{
    public class HomePageViewModel : HorizontalCategorySelectorViewModel
    {
        public HomePagePaginationFilterViewModel PaginationFilterViewModel { get; set; }
        public List<ProductCategory> ParentCategories { get; set; }
        public IList<Product> Products { get; set; }
        public ProductCategory SelectedCategory { get; set; }
    }
}