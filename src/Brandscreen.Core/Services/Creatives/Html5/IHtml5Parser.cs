using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Brandscreen.Framework;
using HtmlAgilityPack;

namespace Brandscreen.Core.Services.Creatives.Html5
{
    public interface IHtml5Parser : IDependency
    {
        Task<Html5ParseResult> Parse(string html);
    }

    public class Html5Parser : IHtml5Parser
    {
        private const string ScriptToAppend = @"
try {
    clickTag = decodeURIComponent(/[\?&]clickTag=([^&]+)/.exec(window.location.search)[1]);
} catch (e) {}
";

        public async Task<Html5ParseResult> Parse(string html)
        {
            var retVal = new Html5ParseResult {Success = false};

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // head -> sript
            var headScriptTags = htmlDocument.DocumentNode.SelectNodes("/html/head/script");

            // head -> sript : clickTag
            HtmlNode clickTag = null;
            foreach (var headScriptTag in headScriptTags)
            {
                using (var sr = new StringReader(headScriptTag.InnerText))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        // note: https://tapfiliate.com/knowledge-base/articles/coding-up-html5-banners-for-use-with-tapfiliate/
                        if (Regex.IsMatch(line.Trim(), "^var\\s+clickTag\\d*\\s*=\\s*['\"].+['\"];$", RegexOptions.IgnoreCase | RegexOptions.Compiled))
                        {
                            clickTag = headScriptTag;
                            break;
                        }
                    }

                    if (clickTag != null) break;
                }
            }
            if (clickTag == null)
            {
                retVal.Error = "click tag not found.";
                return retVal;
            }

            // head -> meta: meta size tag
            Tuple<int, int> size = null;
            var metaSizeTags = htmlDocument.DocumentNode.SelectSingleNode("/html/head/meta[@name='ad.size' and contains(@content, 'width') and contains(@content, 'height')]");
            if (metaSizeTags != null)
            {
                size = await ParseMetaSize(metaSizeTags.GetAttributeValue("content", null));
                if (size == null)
                {
                    retVal.Error = "size is invalid.";
                    return retVal;
                }
            }
            else
            {
                // head -> script: adobe edge script size tag
                var scriptSizeTag = headScriptTags.FirstOrDefault(x => !string.IsNullOrEmpty(x.InnerText) && x.InnerText.TrimStart().StartsWith("AdobeEdge.loadComposition"));
                if (scriptSizeTag == null)
                {
                    retVal.Error = "size not found.";
                    return retVal;
                }
                size = await ParseAdobeEdgeSize(scriptSizeTag.InnerText);
                if (size == null)
                {
                    retVal.Error = "size is invalid.";
                    return retVal;
                }
            }

            // append script to click tag
            clickTag.InnerHtml += ScriptToAppend;

            // all good
            retVal.Success = true;
            retVal.Html = htmlDocument.DocumentNode.OuterHtml;
            retVal.Width = size.Item1;
            retVal.Height = size.Item2;
            return retVal;
        }


        private Task<Tuple<int, int>> ParseMetaSize(string text)
        {
            // example: width=300,height=250

            var match = Regex.Match(text, "width=(\\d+),height=(\\d+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (!match.Success) return Task.FromResult((Tuple<int, int>) null);

            var width = int.Parse(match.Groups[1].Value);
            var height = int.Parse(match.Groups[2].Value);
            return Task.FromResult(new Tuple<int, int>(width, height));
        }

        private async Task<Tuple<int, int>> ParseAdobeEdgeSize(string script)
        {
            /* example:
<script>
   AdobeEdge.loadComposition('728x90-set-1', 'EDGE-355548', {
    scaleToFit: "none",
    centerStage: "both",
    minW: "0px",
    maxW: "undefined",
    width: "728px",
    height: "90px"
}, {"style":{"${symbolSelector}":{"isStage":"true","rect":["undefined","undefined","300px","600px"]}},"dom":{}}, {"style":{"${symbolSelector}":{"isStage":"true","rect":["undefined","undefined","300px","600px"]}},"dom":{}});
</script>
            */

            int? width = null, height = null;
            using (var sr = new StringReader(script))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    var widthMatch = Regex.Match(line, "width:\\s*\"(\\d+)px\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    if (widthMatch.Success)
                    {
                        width = int.Parse(widthMatch.Groups[1].Value);
                        continue;
                    }

                    var heightMatch = Regex.Match(line, "height:\\s*\"(\\d+)px\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    if (heightMatch.Success)
                    {
                        height = int.Parse(heightMatch.Groups[1].Value);
                        continue;
                    }
                }
            }

            return width.HasValue && height.HasValue
                ? new Tuple<int, int>(width.Value, height.Value)
                : null;
        }
    }
}