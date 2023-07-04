using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models;
using yourscope_api.entities;
using yourscope_api.service;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

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
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

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
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

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
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

            ApiResponse response;
            try
            {
                response = await service.LoginMethod(userInfo);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, ex.Message, success: false, exception: ex);
                return StatusCode(response.StatusCode, response);
            }
        }

        #region helpers
        private ApiResponse GenerateMissingFieldsResponse()
        {
            List<string> errors = new();
            foreach (var field in ModelState)
            {
                if (field.Value.Errors.Any(e => e.ErrorMessage.Contains("is required")))
                    errors.Add($"{field.Key} is a required field.");
            }

            ApiResponse response = new(StatusCodes.Status400BadRequest, "Bad request.", errors: errors);

            return response;
        }
        #endregion
    }
}
