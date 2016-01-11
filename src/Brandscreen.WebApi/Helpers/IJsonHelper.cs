using System.Web;
using System.Web.Mvc;
using Brandscreen.Framework;
using Brandscreen.WebApi.Jsons;

namespace Brandscreen.WebApi.Helpers
{
    public interface IJsonHelper : IDependency
    {
        IHtmlString JsonFor<T>(T obj);
    }

    public class JsonHelper : IJsonHelper
    {
        private readonly HtmlHelper _htmlHelper;

        public JsonHelper(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IHtmlString JsonFor<T>(T obj)
        {
            return _htmlHelper.Raw(obj.ToJson());
        }
    }
}