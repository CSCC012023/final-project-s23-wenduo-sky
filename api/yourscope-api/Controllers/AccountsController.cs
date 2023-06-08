using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models;
using yourscope_api.service;

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
            try
            {
                return Ok(service.CheckEmailRegistered(email));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
