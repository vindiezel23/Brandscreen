using System;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Framework;
using HtmlAgilityPack;

namespace Brandscreen.Core.Services.Creatives.Swiffy
{
    public interface ISwiffyParser : IDependency
    {
        Task<SwiffyParseResult> Parse(string html);
    }

    public class SwiffyParser : ISwiffyParser
    {
        public Task<SwiffyParseResult> Parse(string html)
        {
            return Task.Run(() =>
            {
                var retVal = new SwiffyParseResult {Success = false};

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                // head -> sript
                var headScriptTags = htmlDocument.DocumentNode.SelectNodes("/html/head/script");

                // head -> sript : runtime
                var runtimeTag = headScriptTags.FirstOrDefault(x => !string.IsNullOrEmpty(x.Attributes["src"]?.Value) && x.Attributes["src"].Value.EndsWith("runtime.js", StringComparison.OrdinalIgnoreCase));
                if (runtimeTag == null)
                {
                    retVal.Error = "runtime not found.";
                    return retVal;
                }

                // head -> sript : swiffy object
                var swiffyObjectTag = headScriptTags.FirstOrDefault(x => !x.HasAttributes && !string.IsNullOrEmpty(x.InnerText) && x.InnerText.Trim().StartsWith("swiffyobject"));
                if (swiffyObjectTag == null)
                {
                    retVal.Error = "swiffy object not found.";
                    return retVal;
                }

                // body -> div : width & height 
                var swiffyContainerTag = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='swiffycontainer' and contains(@style, 'width') and contains(@style, 'height')]");
                var style = swiffyContainerTag?.GetAttributeValue("style", null);
                if (string.IsNullOrEmpty(style))
                {
                    retVal.Error = "size not found.";
                    return retVal;
                }

                // style
                var styleDic = style.Split(';').Select(x => x.Trim())
                    .Select(x =>
                    {
                        var kv = x.Split(':').Select(xy => xy.Trim()).ToArray();
                        return new {Key = kv[0], Value = kv[1]};
                    })
                    .ToDictionary(x => x.Key, x => x.Value.Replace("px", ""));

                int width, height;
                if (!int.TryParse(styleDic["width"], out width) || !int.TryParse(styleDic["height"], out height))
                {
                    retVal.Error = "size is invalid.";
                    return retVal;
                }

                // all good
                retVal.Success = true;
                retVal.Runtime = runtimeTag.Attributes["src"].Value;
                retVal.Object = swiffyObjectTag.InnerText.Trim();
                retVal.Width = width;
                retVal.Height = height;
                return retVal;
            });
        }
    }
}