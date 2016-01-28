using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartClinic.Application.AppServices;

namespace SmartClinic.API.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly DoctorAppService _doctorAppService;

        public DoctorController(DoctorAppService doctorAppService)
        {
            _doctorAppService = doctorAppService;
        }

        [HttpGet]
        [Route("api/doctors")]
        public HttpResponseMessage GetDoctors()
        {
            try
            {
                var doctors = _doctorAppService.GetDoctors();

                return Request.CreateResponse(HttpStatusCode.OK, doctors);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
