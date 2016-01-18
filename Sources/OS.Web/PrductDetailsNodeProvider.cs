using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Dependency;

namespace OS.Web
{
    public class PrductDetailsNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            ProductsBL productsBL = DI.Resolve<ProductsBL>();
            List<Product> products = productsBL.Get(null);

            ProductCategoriesBL productCategoriesBL = DI.Resolve<ProductCategoriesBL>();

            foreach (Product product in products)
            {
                List<ProductCategory> productCategories = productCategoriesBL.GetParentCategories(product.Categories.First().Id);

                ProductCategory productCategory = product.Categories.First();

                DynamicNode productCategoryNode = new DynamicNode
                        {
                            Key = "product_" + product.Id,
                            Title = product.Name,
                            Controller = "Products",
                            Action = "Details",
                            
                    };
                productCategoryNode.RouteValues.Add("productId", product.Id);
                productCategoryNode.RouteValues.Add("categoryId", product.Categories.First().Id);

                productCategoryNode.ParentKey = "Товари";
                nodes.Add(productCategoryNode);
            }

            return nodes;
        }
    }
}