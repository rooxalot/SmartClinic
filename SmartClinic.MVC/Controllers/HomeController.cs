using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartClinic.Application.AppServices;

namespace SmartClinic.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserAppService _userAppService;
        private bool isAuthenticated;

        public HomeController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public ActionResult Index()
        {
            if(isAuthenticated)
                return View();
            else
                return View("Login");
        }

        public ActionResult Login()
        {
            ViewBag.Title = "SmartClinic - Login";
            ViewBag.ShowErrorDiv = false;
            isAuthenticated = false;

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var login = form["Login"];
            var password = form["Password"];

            var authenticated = _userAppService.Authenticate(login, password);

            if (authenticated)
            {
                isAuthenticated = true;
                return View("Index");
            }
            else
            {
                isAuthenticated = false;
                ViewBag.ShowErrorDiv = true;
                return View();
            }
                
        }
    }
}