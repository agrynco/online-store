#region Usings
using System.Linq;
using System.Web.Mvc;
using OS.Business.Logic;
using OS.Web.Models;
#endregion

namespace OS.Web.Controllers.Administration
{
    public class ProductCategoriesController : BaseAdminController
    {
        private readonly ProductCategoriesBL _productCategoriesBL;

        public ProductCategoriesController(ProductCategoriesBL productCategoriesBL)
        {
            _productCategoriesBL = productCategoriesBL;
        }

        public ActionResult Index(int? parentId)
        {
            ProductCategoriesViewModel viewModel = new ProductCategoriesViewModel
                {
                    ProductCategories = _productCategoriesBL.GetCategories(parentId).ToList()
                };

            if (parentId != null)
            {
                viewModel.LevelUpProductCategory = _productCategoriesBL.GetCategory(parentId.Value);
            }

            return View(viewModel);
        }
    }
}