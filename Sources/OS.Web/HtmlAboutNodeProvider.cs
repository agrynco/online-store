using System.Collections.Generic;
using MvcSiteMapProvider;
using OS.Business.Domain;

namespace OS.Web
{
    public class HtmlAboutNodeProvider : DynamicNodeProviderBase
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
            dynamicNode.RouteValues.Add("htmlContentCode", HtmlContentCode.About);
            nodes.Add(dynamicNode);

            return nodes;
        }
    }
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

    public class HtmlContactsEditNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            DynamicNode dynamicNode = new DynamicNode
            {
                ParentKey = "Online Store",
                Controller = "HtmlContents",
                Action = "Edit"
            };
            dynamicNode.RouteValues.Add("htmlContentCode", HtmlContentCode.Contacts);
            nodes.Add(dynamicNode);

            return nodes;
        }
    }

    public class HtmlAboutEditNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> nodes = new List<DynamicNode>();

            DynamicNode dynamicNode = new DynamicNode
            {
                ParentKey = "Online Store",
                Controller = "HtmlContents",
                Action = "Edit"
            };
            dynamicNode.RouteValues.Add("htmlContentCode", HtmlContentCode.About);
            nodes.Add(dynamicNode);

            return nodes;
        }
    }
}