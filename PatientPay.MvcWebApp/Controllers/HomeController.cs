using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(Admin);
        }

        public ActionResult GetAdminDetails()
        {
            return Json(Admin, JsonRequestBehavior.AllowGet);
        }
    }
}