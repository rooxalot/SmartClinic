using System.Web.Mvc;
using SmartClinic.Application.AppServices;
using SmartClinic.Application.AppModels.User;
using SmartClinic.Infrastructure.CrossCutting.Security;


namespace SmartClinic.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Properties

        private readonly UserAppService _userAppService;
        private readonly ClinicAppService _clinicAppService;

        #endregion

        #region Constructor

        public HomeController(UserAppService userAppService, ClinicAppService clinicAppService)
        {
            _userAppService = userAppService;
            _clinicAppService = clinicAppService;
        }

        #endregion

        #region Actions

        [Authorize]
        public ActionResult Index()
        {
            if (_userAppService.HasUserAuthenticated())
                return View();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Title = "SmartClinic - Login";
            ViewBag.ShowErrorDiv = false;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection form)
        {
            var login = form["Login"];
            var password = form["Password"];

            var authenticatedUser = _userAppService.Authenticate(login, password);

            if (authenticatedUser)
            {
                _clinicAppService.RegisterClinic();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ShowErrorDiv = true;
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            _userAppService.LogoutUser();
            return RedirectToAction("Login");
        }

        #endregion
    }
}