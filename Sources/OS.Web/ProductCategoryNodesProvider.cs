using System.Collections.Generic;
using MvcSiteMapProvider;

namespace OS.Web
{
    public class ProductCategoryNodesProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            ProcessCategory(nodes, "Online Store", null);

            return nodes;
        }

        private void ProcessCategory(List<DynamicNode> nodes, string parentKey, int? parentCategoryId)
        {
//            List<ProductCategory> productCategories = _productCategoriesBL.GetCategories(parentCategoryId);
//
//            foreach (ProductCategory productCategory in productCategories)
//            {
//                DynamicNode productCategoryNode = new DynamicNode
//                {
//                    ParentKey = parentKey,
//                    Title = productCategory.Name,
//                    Key = "ProductCategory_" + productCategory.Id,
//                    Action = "ChangeCategory",
//                    Controller = "Home"
//                };
//
//                productCategoryNode.RouteValues.Add("categoryId", productCategory.Id);
//                nodes.Add(productCategoryNode);
//
//                List<Product> products = _productsBL.Get(new ProductsFilter
//                {
//                    ParentId = productCategory.Id
//                });
//
//                
//
//                ProcessCategory(nodes, productCategoryNode.Key, productCategory.Id);
//            }
        }
    }
}