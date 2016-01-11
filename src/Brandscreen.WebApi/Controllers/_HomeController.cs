using System.Web.Mvc;

namespace Brandscreen.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Help");
        }

        public ActionResult AngularIndex(object url)
        {
            return View(url);
        }
    }
}