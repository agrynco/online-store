#region Usings
using System.Collections.Generic;
using System.Web;
using OS.Business.Domain;
#endregion

namespace OS.Web.Models.ProductViewModels
{
    public class ProductCreateOrEditViewModel : BaseCreateOrEditViewModel
    {
        public override int? Id
        {
            get { return Product.Id == 0 ? (int?) null : Product.Id; }
            set { Product.Id = value ?? 0; }
        }

        public Product Product { get; set; }

        public int ParentCategoryId { get; set; }

        public List<HttpPostedFileBase> PostedProductPhotos { get; set; }

        public string BrandName { get; set; }
        public string CountryName { get; set; }
    }
}