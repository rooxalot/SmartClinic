using System;
using System.Web.Http;
using System.Web.Http.Results;
using SmartClinic.Application.AppServices;

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
        [Route("api/appointments")]
        public IHttpActionResult GetPendingAppointments()
        {
            try
            {
                var pendingAppointments = _appointmentAppService.GetPendingAppointments();

                return Ok(pendingAppointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}