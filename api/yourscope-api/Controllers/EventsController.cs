using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yourscope_api.entities;
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
    }
}
