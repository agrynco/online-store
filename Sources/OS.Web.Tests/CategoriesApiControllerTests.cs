using System.Collections.Generic;
using NUnit.Framework;
using OS.Dependency;
using OS.Web.Controllers.Api;
using OS.Web.Models.ProductCategoryViewModels;

namespace OS.Web.Tests
{
    [TestFixture]
    public class CategoriesApiControllerTests
    {
        [Test]
        public void SearchCategories()
        {
            DI.Configure();

            DI.Register<CategoriesController>();

            CategoriesController categoriesController = DI.Resolve<CategoriesController>();

            IList<ProductCategoryAutocompleteItem> productCategoryAutocompleteItems = categoriesController.SearchCategories("о");

            Assert.That(productCategoryAutocompleteItems.Count, Is.EqualTo(10));
        }
    }
}
