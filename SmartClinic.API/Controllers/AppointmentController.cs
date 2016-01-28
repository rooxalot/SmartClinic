using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartClinic.Application.AppServices;
using SmartClinic.Application.ViewModels;

namespace SmartClinic.API.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly AppointmentAppService _appointmentAppService;

        public AppointmentController(AppointmentAppService appointmentAppService)
        {
            _appointmentAppService = appointmentAppService;
        }

        [HttpGet]
        [Route("api/appointments/pending")]
        public HttpResponseMessage GetPendingAppointments()
        {
            try
            {
                var pendingAppointments = _appointmentAppService.GetPendingAppointments();

                return Request.CreateResponse(HttpStatusCode.OK, pendingAppointments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/appointments/doctor")]
        public HttpResponseMessage GetAppointmentsByDoctor(DoctorViewModel model)
        {
            try
            {
                var appointments = _appointmentAppService.GetAppointmentsByDoctor(model);
                return Request.CreateResponse(HttpStatusCode.OK, appointments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/appointments/new")]
        public HttpResponseMessage CreateAppointment(AppointmentViewModel model)
        {
            try
            {
                _appointmentAppService.CreateAppointment(model);
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}