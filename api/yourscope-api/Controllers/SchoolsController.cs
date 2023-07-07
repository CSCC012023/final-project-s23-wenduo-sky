﻿using Microsoft.AspNetCore.Http;
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
    public class SchoolsController : ControllerBase
    {
        #region fields and constructors
        private readonly ISchoolService service;

        public SchoolsController(ISchoolService service)
        {
            this.service = service;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            ApiResponse response;
            try
            {
                response = service.GetSchoolsMethod();
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }
    }
}
