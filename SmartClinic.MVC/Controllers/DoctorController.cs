using System.Web.Mvc;
using SmartClinic.Application.AppServices;
using System;
using SmartClinic.Application.AppModels.Doctor;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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


        //Listagem de médicos
        public ActionResult Index()
        {
            var doctors = _doctorAppService.GetActiveDoctors();
            return View(doctors);
        }

        public ActionResult Detail(Guid id)
        {
            var doctor = _doctorAppService.GetDoctorById(id);
            return View(doctor);
        }

        //Criação de médico
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DoctorModel doctor)
        {
            if (!ModelState.IsValid)
                return View();

            _doctorAppService.RegisterDoctor(doctor);
            return RedirectToAction("Index");
        }

        //Edição de médico
        public ActionResult Edit(Guid id)
        {
            var doctor = _doctorAppService.GetDoctorById(id);
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(DoctorModel doctor)
        {
            var validations = new List<ValidationResult>();

            Infrastructure.CrossCutting.Validations.ViewModelValidator.Validate(doctor, out validations);
            if (!ModelState.IsValid)
                return View(doctor);

            _doctorAppService.EditDoctor(doctor);
            return RedirectToAction("Index", "Doctor");
        }

        //Exclusão de médico
        [HttpPost]
        public void Delete(Guid id)
        {
            try
            {
                _doctorAppService.RemoveDoctor(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}