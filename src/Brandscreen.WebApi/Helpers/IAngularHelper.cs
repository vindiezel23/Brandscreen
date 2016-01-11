using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Brandscreen.Framework;
using Brandscreen.WebApi.Models.Mvc.Account;

namespace Brandscreen.WebApi.Helpers
{
    public interface IAngularHelper : IDependency
    {
        IHtmlString CurrentUser();
    }

    public class AngularHelper : IAngularHelper
    {
        private readonly HtmlHelper _htmlHelper;
        private readonly IMappingEngine _mapping;

        public AngularHelper(HtmlHelper htmlHelper, IMappingEngine mapping)
        {
            _htmlHelper = htmlHelper;
            _mapping = mapping;
        }

        public IHtmlString CurrentUser()
        {
            var user = _mapping.Map<CurrentUserViewModel>(_htmlHelper.ViewContext.HttpContext.User.Identity);
            return _htmlHelper.Json().JsonFor(user);
        }
    }
}