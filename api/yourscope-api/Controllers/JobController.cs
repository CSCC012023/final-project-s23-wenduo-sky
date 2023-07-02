using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.Models.Request;
using yourscope_api.service;
using yourscope_api.ServiceInterfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace yourscope_api.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class JobController : ControllerBase
    {
        #region constructors and class fields
        private readonly IJobService service;

        public JobController(IJobService service)
        {
            this.service = service;
        }
        #endregion

        [HttpPost]
        [Route("posting")]
        public IActionResult CreateJobPosting([FromBody] JobPostingCreation posting)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

            try
            {
                service.CreateJobPosting(posting);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("posting")]
        public IActionResult GetJobPostings(int? userId, bool? applied, int count, int offset)
        {
            try {

                JobFilter filters = new JobFilter
                {
                    UserId = userId,
                    Applied = applied,
                    Count = count,
                    Offset = offset
                };

                return Ok(service.GetJobPostings(filters));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("posting/{id}")]
        public IActionResult DeleteJobPostings(int id)
        {
            try
            {
                service.DeleteJobPosting(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("posting/count")]
        public IActionResult CountJobPosting(int? userId, bool? applied)
        {
            JobFilter filters = new JobFilter
            {
                UserId = userId,
                Applied = applied
            };

            try
            {
                return Ok(service.CountJobPostings(filters));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
