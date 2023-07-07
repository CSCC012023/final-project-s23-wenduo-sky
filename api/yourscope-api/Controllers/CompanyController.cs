﻿using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.service;

namespace yourscope_api.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region constructors and class fields
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }
        #endregion

        [HttpGet]
        [Route("check-company-exist/{company}")]
        public IActionResult CheckCompanyExists(string company)
        {
            ApiResponse response;
            try
            {
                response = service.CheckCompanyExistsMethod(company);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterCompany([FromBody] Company companyInfo)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

            ApiResponse response;
            try
            {
                response = await service.RegisterCompanyMethod(companyInfo);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            ApiResponse response;
            try
            {
                response = service.GetCompaniesMethod();
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
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
