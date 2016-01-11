using System.Web.Helpers;
using HtmlAgilityPack;

namespace Brandscreen.WebApi.Helpers
{
    public class AntiForgeryTokenHelper
    {
        public static string GenerateAntiForgeryToken()
        {
            var html = AntiForgery.GetHtml().ToString();
            var htmlNode = HtmlNode.CreateNode(html);
            var tokenAttr = htmlNode.Attributes["value"];
            return tokenAttr.Value;
        }
    }
}