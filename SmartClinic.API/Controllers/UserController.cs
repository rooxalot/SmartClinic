
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
        [Route("api/user/register")]
        public HttpResponseMessage Register(RegisterUserViewModel viewModel) 
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _appService.RegisterUser(viewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, (ex.Message + ": " + ex.InnerException));
            }
        }

        [HttpDelete]
        [Route("api/user/remove/{id}")]
        public HttpResponseMessage Remove(Guid id)
        {
            try
            {
                _appService.RemoveUser(id);

                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, (ex.Message + ": " + ex.InnerException));
            }

        }

        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage Update(Guid id, [FromBody] ChangeUserInformationViewModel viewModel)
        {
            try
            {
                viewModel.Id = id;
                _appService.UpdateUser(viewModel);
                return Request.CreateResponse(HttpStatusCode.OK, viewModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, (ex.Message + ": " + ex.InnerException));
            }
        }
    }
}
