using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models;
using yourscope_api.entities;
using yourscope_api.service;
using Microsoft.AspNetCore.Authorization;

namespace yourscope_api.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region fields and constructors
        private readonly IAccountsService service;

        public AccountsController(IAccountsService service)
        {
            this.service = service;
        }
        #endregion

        [HttpGet]
        [Route("check-registered/{email}")]
        public IActionResult CheckEmailRegistered(string email)
        {
            ApiResponse response;
            try
            {
                bool registered = service.CheckEmailRegistered(email);

                response = new(StatusCodes.Status200OK, data: registered);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("{email}/send-password-reset-email")]
        public async Task<IActionResult> SendPasswordResetEmail(string email)
        {
            ApiResponse response;
            try
            {
                response = await service.SendPasswordResetEmailMethod(email);
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("student/register")]
        public async Task<IActionResult> RegisterStudent([FromBody] UserRegistrationDto userInfo)
        {
            ApiResponse response;
            try
            {
                response = await service.RegisterStudentMethod(userInfo);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("employer/register")]
        public async Task<IActionResult> RegisterEmployer([FromBody] UserRegistrationDto userInfo)
        {
            try
            {
                return await service.RegisterEmployerMethod(userInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userInfo)
        {
            try
            {
                return await service.LoginMethod(userInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
