#region Usings
using System.Collections.Generic;
using OS.Business.Domain;
#endregion

namespace OS.Web.Models
{
    public class HorizontalCategorySelectorViewModel
    {
        public HorizontalCategorySelectorViewModel()
        {
            RootCategories = new List<ProductCategory>();
        }

        public IList<ProductCategory> RootCategories { get; set; }
        public ProductCategory SelectedCategory { get; set; }
    }
}