using System.Collections.Generic;
using MvcSiteMapProvider;
using OS.Business.Domain;

namespace OS.Web.SiteMapNodeProviders.HtmlContentNodeProviders
{
    public class HtmlContactsNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            DynamicNode dynamicNode = new DynamicNode
                {
                    ParentKey = "Online Store",
                    Controller = "HtmlContents",
                    Action = "Index"
                };
            dynamicNode.RouteValues.Add("htmlContentCode", HtmlContentCode.Contacts);
            nodes.Add(dynamicNode);

            return nodes;
        }
    }
}