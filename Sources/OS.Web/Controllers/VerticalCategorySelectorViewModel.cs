using System.Collections.Generic;

namespace OS.Web.Controllers
{
    public class VerticalCategorySelectorItemViewModel
    {
        public VerticalCategorySelectorItemViewModel()
        {
            ChildCategories = new List<VerticalCategorySelectorItemViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<VerticalCategorySelectorItemViewModel> ChildCategories { get; set; } 
    }

    public class VerticalCategorySelectorViewModel
    {
        public List<VerticalCategorySelectorItemViewModel>  Categories { get; set; }
    }
}