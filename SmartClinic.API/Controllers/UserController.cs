
using SmartClinic.Application.AppServices;
using SmartClinic.Application.ViewModels.UserModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartClinic.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserAppService _appService;

        public UserController(UserAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public HttpResponseMessage Authenticate(AuthenticateUserViewModel viewModel)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _appService.AuthenticateUser(viewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Register(RegisterUserViewModel viewModel) 
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _appService.RegisterUser(viewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
