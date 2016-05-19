namespace OS.Web.Models
{
    public class HomePagePaginationFilterViewModel : PaginationFilterViewModel
    {
        public int? ParentCategoryId { get; set; }
        public string SearchTerm { get; set; }
    }
}