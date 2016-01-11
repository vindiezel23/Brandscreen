using System.Web.Mvc;

namespace Brandscreen.WebApi.Controllers
{
    public class TemplateController : Controller
    {
        public ActionResult Render(string feature, string name)
        {
            var templatePath = $"~/app/{feature}/templates/{name}";
            if (!System.IO.File.Exists(Server.MapPath(templatePath)))
            {
                return HttpNotFound();
            }
            return PartialView(templatePath);
        }
    }
}