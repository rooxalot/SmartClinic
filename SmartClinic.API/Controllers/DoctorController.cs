using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartClinic.Application.AppServices;
using SmartClinic.Application.ViewModels.DoctorModels;

namespace SmartClinic.API.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly DoctorAppService _appService;

        public DoctorController(DoctorAppService appService)
        {
            _appService = appService;
        }

        //teste
        [HttpGet]
        [Route("api/doctor")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _appService.GetModels());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, (ex.Message + ": " + ex.InnerException));
            }
        }

        [HttpPost]
        [Route("api/doctor/register")]
        public HttpResponseMessage Register(RegisterDoctorViewModel viewModel)
        {
            try
            {
                _appService.RegisterDoctor(viewModel);
                return Request.CreateResponse(HttpStatusCode.OK, viewModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, (ex.Message + ": " + ex.InnerException));
            }
        }
    }
}
