using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Models.HtmlHelpers
{
    public static class ImageHelpers
    {
        public static IHtmlString Image(this HtmlHelper html, string src)
        {
            TagBuilder tag = new TagBuilder("img");
            tag.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}