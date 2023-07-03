using Firebase.Auth;
using Google.Api.Gax;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.Models.DbModels;
using yourscope_api.Models.Reponse;
using yourscope_api.Models.Request;
using yourscope_api.service;
using yourscope_api.ServiceInterfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

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
            try
            {
                var jobId = service.CreateJobPosting(posting);
                return StatusCode(201, new ApiResponse(201, data : jobId, success : true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success : false));
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

                var jobPostings = service.GetJobPostings(filters);
                return Ok(new ApiResponse(200, data: jobPostings, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
            }
        }

        [HttpDelete]
        [Route("posting/{id}")]
        public IActionResult DeleteJobPostings(int id)
        {
            try
            {
                service.DeleteJobPosting(id);
                return Ok(new ApiResponse(200, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
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
                var numJobPostings = service.CountJobPostings(filters);
                return Ok(new ApiResponse(200, data: numJobPostings, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
            }
        }

        [HttpPost]
        [Route("application")]
        public IActionResult CreateJobApplication([FromBody] JobApplicationCreation application)
        {
            try
            {
                var jobId = service.CreateJobApplication(application);
                return Ok(new ApiResponse(200, data: jobId, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
            }
        }

        [HttpGet]
        [Route("application/{id}")]
        public IActionResult GetJobApplications(int id)
        {
            try
            {
                var applications = service.GetJobApplications(id);
                return Ok(new ApiResponse(200, data: applications, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
            }
        }
    }
}
