namespace OS.Business.Domain
{
    public class ProductCategoriesFilter
    {
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public bool IgnoreParentId { get; set; }
    }
}