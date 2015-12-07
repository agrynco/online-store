using OS.Business.Domain;

namespace OS.Web.Models.ProductViewModels
{
    public class ProductCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public override int? Id
        {
            get { return Product?.Id; }
            set { Product.Id = value ?? 0; }
        }

        public Product Product { get; set; }
    }
}