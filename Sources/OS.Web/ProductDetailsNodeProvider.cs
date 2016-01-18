using System.Collections.Generic;
using MvcSiteMapProvider;
using OS.Business.Domain;
using OS.Business.Logic;
using OS.Dependency;

namespace OS.Web
{
    public class ProductDetailsNodeProvider : DynamicNodeProviderBase
    {
        private readonly ProductCategoriesBL _productCategoriesBL;
        private readonly ProductsBL _productsBL;

        public ProductDetailsNodeProvider()
        {
            _productCategoriesBL = DI.Resolve<ProductCategoriesBL>();
            _productsBL = DI.Resolve<ProductsBL>();
        }

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            ProcessCategory(nodes, "Online Store", null);

            return nodes;
        }

        private void ProcessCategory(List<DynamicNode> nodes, string parentKey, int? parentCategoryId)
        {
            List<ProductCategory> productCategories = _productCategoriesBL.GetCategories(parentCategoryId);

            foreach (ProductCategory productCategory in productCategories)
            {
                DynamicNode productCategoryNode = new DynamicNode
                    {
                        ParentKey = parentKey,
                        Title = productCategory.Name,
                        Key = "ProductCategory_" + productCategory.Id,
                        Action = "ChangeCategory",
                        Controller = "Home"
                };

                productCategoryNode.RouteValues.Add("categoryId", productCategory.Id);
                nodes.Add(productCategoryNode);

                List<Product> products = _productsBL.Get(new ProductsFilter
                    {
                        ParentId = productCategory.Id
                    });

                foreach (Product product in products)
                {
                    DynamicNode productNode = new DynamicNode
                        {
                            ParentKey = productCategoryNode.Key,
                            Title = product.Name,
                            Key = productCategoryNode.Key + "_Product_" + product.Id,
                            Controller = "Home",
                            Action = "Details"
                        };
                    productNode.RouteValues.Add("productId", product.Id);
                    productNode.RouteValues.Add("categoryId", productCategory.Id);

                    nodes.Add(productNode);
                }

                ProcessCategory(nodes, productCategoryNode.Key, productCategory.Id);
            }
        }
    }
}