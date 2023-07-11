using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.Models;
using yourscope_api.entities;
using yourscope_api.service;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using yourscope_api.Models.DbModels;
using Google.Api.Gax;

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

        /// <summary>
        /// Gets the number of registered schools in the system.
        /// </summary>
        /// <returns>The number of registered schools in the system.</returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult GetSchools()
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

        /// <summary>
        /// Adds course(s) to a given school
        /// </summary>
        /// <param name="courses">List of course(s) to add, if a course already exists, it uses the data that's already in the table.</param>
        /// <param name="schoolId">Id of school to add courses to</param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [HttpPost]
        [Route("add-courses/{schoolId}")]
        public IActionResult CourseInit([FromBody] List<Course> courses, int schoolId)
        {
            try
            {
                service.PopulateCourseData(courses, schoolId);
                return StatusCode(201, new ApiResponse(201, success: true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, success: false));
            }
        }
    }
}
