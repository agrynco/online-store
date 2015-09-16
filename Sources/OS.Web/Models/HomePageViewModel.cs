namespace OS.Web.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            HorizontalCategorySelectorViewModel = new HorizontalCategorySelectorViewModel();
        }

        public HorizontalCategorySelectorViewModel HorizontalCategorySelectorViewModel { get; set; } 
    }
}