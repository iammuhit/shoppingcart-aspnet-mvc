using System;
using System.Text;
using System.Web.Mvc;
using ShoppingCart.WebUI.Models;

namespace ShoppingCart.WebUI.Helpers
{
    public static class PaginationHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PaginationInfo paginationInfo, Func<int, string> pageUrl)
        {
            StringBuilder pagination = new StringBuilder();

            if (paginationInfo.TotalItems < paginationInfo.ItemsPerPage)
            {
                return null;
            }

            for (int page = 1; page <= paginationInfo.TotalPages; page++)
            {
                TagBuilder pageItem = new TagBuilder("li");
                TagBuilder pageLink = new TagBuilder("a");

                pageLink.MergeAttribute("href", pageUrl(page));
                pageLink.AddCssClass("page-link");
                pageLink.InnerHtml = page.ToString();

                pageItem.AddCssClass("page-item");
                pageItem.InnerHtml = pageLink.ToString();

                if (page == paginationInfo.CurrentPage)
                {
                    pageItem.AddCssClass("active");
                }

                pagination.Append(pageItem.ToString());
            }

            return MvcHtmlString.Create(pagination.ToString());
        }
    }
}
