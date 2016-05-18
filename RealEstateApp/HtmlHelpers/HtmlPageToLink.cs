using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace RealEstateApp.HtmlHelpers
{
    public static class HtmlPageToLink
    {
        public static string PageToLink(this HtmlHelper html, int TPage)
        {
            UrlHelper url = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);

            string controllerName = url.RequestContext.RouteData.Values["controller"].ToString();

            int Page = int.Parse(url.RequestContext.RouteData.Values["PageIndex"].ToString());

            StringBuilder sb = new StringBuilder();

            if (Page != 1)
            {
                string first = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = 1 }) + "><img src = /Areas/Administrator/Content/images/first.gif /></a>";
                sb.Append(first);

                string previous = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (Page - 1) }) + "><img src = /Areas/Administrator/Content/images/previous.gif /></a>";

                sb.Append(previous);

                sb.Append("...&nbsp&nbsp");
            }
            for (int i = (Page >= 7 ? (Page - 5) : 1); i <= (Page + 5 < TPage ? (Page + 5) : TPage); i++)
            {
                if (i == Page)
                {
                    sb.Append(i);
                    sb.Append("&nbsp&nbsp");
                    continue;
                }
                var link = html.ActionLink(i.ToString(), "Page", new { PageIndex = i }, new { @class = "aPage" });
                sb.Append(link.ToString());
                sb.Append("&nbsp&nbsp");
            }
            if (Page != TPage)
            {
                sb.Append("...&nbsp&nbsp");
                string next = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (Page + 1) }) + "><img src=/Areas/Administrator/Content/images/next.gif></a>";
                sb.Append(next);

                string last = "<a class=\"aPage\" href=" + url.Action("Page", new { PageIndex = (TPage) }) + "><img src=/Areas/Administrator/Content/images/last.gif></a>";

                sb.Append(last);
            }
            return sb.ToString();
        }
    }
}