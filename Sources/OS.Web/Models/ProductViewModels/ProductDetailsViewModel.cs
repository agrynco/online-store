using OS.Business.Domain;

namespace OS.Web.Models.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public int? CategoryId { get; set; } 
        public Product Product { get; set; }
    }
}