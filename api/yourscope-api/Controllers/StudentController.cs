using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.service;

namespace yourscope_api.Controllers
{
    [Route("api/[controller]/v1")]
    public class StudentController : Controller
    {
        #region fields and constructor
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        #endregion

        /// <summary>
        /// Gets the schedule of a student given their user ID.
        /// </summary>
        /// <param name="studentID">The user ID of the student whose schedule is to be retrieved.</param>
        /// <returns>A schedule object containing all the required scheduling information, including courses added onto the schedule.</returns>
        [HttpGet]
        [Route("schedule/{studentID}")]
        public async Task<IActionResult> GetStudentSchedule(int studentID)
        {
            ApiResponse response;
            try
            {
                response = await service.GetStudentScheduleMethod(studentID);
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Create a schedule for the a student given their user ID.
        /// </summary>
        /// <param name="studentID">The user ID of the student whose schedule is to be created.</param>
        /// <returns>true if the creation was successful, 404 status if the user does not exist, 400 if the user is not a student, and 500 otherwise.</returns>
        [HttpPost]
        [Route("schedule/{studentID}")]
        public async Task<IActionResult> CreateStudentSchedule(int studentID)
        {
            ApiResponse response;
            try
            {
                response = await service.CreateStudentScheduleMethod(studentID);
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

    }
}

