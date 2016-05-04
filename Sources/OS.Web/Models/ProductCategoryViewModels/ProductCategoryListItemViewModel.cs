namespace OS.Web.Models.ProductCategoryViewModels
{
    public class ProductCategoryListItemViewModel
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool Publish { get; set; }
        public bool IsDeleted { get; set; }

        public int Order { get; set; }
    }
}