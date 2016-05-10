using System.Web.Mvc;
using SmartClinic.Application.AppServices;
using System;
using SmartClinic.Application.AppModels.Doctor;

namespace SmartClinic.MVC.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        #region Properties

        DoctorAppService _doctorAppService;

        #endregion

        #region Constructor

        public DoctorController(DoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }

        #endregion


        #region Actions

        public ActionResult Index()
        {
            var doctors = _doctorAppService.GetDoctors();
            return View(doctors);
        }

        public ActionResult Edit(Guid id)
        {
            var doctor = _doctorAppService.GetDoctorById(id);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(DoctorModel doctor)
        {
            _doctorAppService.EditDoctor(doctor);
            return RedirectToAction("Index", "Doctor");
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            _doctorAppService.RemoveDoctor(id);
            return View("Index");
        }

        #endregion
    }
}