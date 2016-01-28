namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryAutocompleteItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] ParentCategories { get; set; }
    }
}