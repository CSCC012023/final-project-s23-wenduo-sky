using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
using yourscope_api.Models.Request;
using yourscope_api.service;

namespace yourscope_api.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        #region fields and constructors
        private readonly IEventsService service;

        public EventsController(IEventsService service)
        {
            this.service = service;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreationDto eventDetails)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, GenerateMissingFieldsResponse());

            ApiResponse response;
            try
            {
                response = await service.CreateEventMethod(eventDetails);
            }
            catch (Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            ApiResponse response;
            try
            {
                response = await service.DeleteEventMethod(id);
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEvents(int? userId, int? schoolId, int? offset, int? count)
        {
            #region initialize event filter object.
            EventFilter filters = new()
            {
                UserId = userId,
                SchoolId = schoolId,
            };
            if (offset is not null)
                filters.Offset = (int) offset;
            if (count is not null)
                filters.Count = (int) count;
            #endregion

            ApiResponse response;
            try
            {
                response = await service.GetEventsMethod(filters);
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
