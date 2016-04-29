
using System.Web.Mvc;

namespace SmartClinic.MVC.Controllers
{
    public class DoctorController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}