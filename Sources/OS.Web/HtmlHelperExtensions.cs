﻿using System;
using System.Text;
using System.Web.Mvc;
using AGrynCo.Lib.ResourcesUtils;
using OS.Web.Models;

namespace OS.Web
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, PaginationFilterViewModel paginationFilterViewModel,
            Func<int, MvcHtmlString> pageItemActionLinkFunc,
            Func<MvcHtmlString> prevActionLinkFunc,
            Func<MvcHtmlString> nextActionLinkFunc)
        {
            string htmlTemplate = ResourceReader.ReadAsString(typeof (HtmlHelperExtensions), "OS.Web.HtmlTemplates.paginationTemplate.html");

            htmlTemplate = htmlTemplate.Replace("{{prev}}", prevActionLinkFunc != null ? htmlHelper.Raw(prevActionLinkFunc()).ToString() : "");

            htmlTemplate = htmlTemplate.Replace("{{next}}", nextActionLinkFunc != null ? htmlHelper.Raw(nextActionLinkFunc()).ToString() : "");

            StringBuilder itemsStringBuilder = new StringBuilder();
            for (int i = 0; i < paginationFilterViewModel.GetPagesCount(); i++)
            {
                itemsStringBuilder.AppendFormat("<li {0}>{1}</li>",
                    (i + 1) == paginationFilterViewModel.PageNumber ? "class='current-page'" : "",
                    htmlHelper.Raw(pageItemActionLinkFunc(i + 1)));
            }

            string rawString = htmlTemplate.Replace("{{pageItems}}", itemsStringBuilder.ToString());
            MvcHtmlString result = new MvcHtmlString(rawString);
            return result;
        }
    }
}