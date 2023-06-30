using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using yourscope_api.Models.DbModels;

namespace yourscope_api.Controllers
{
    [ApiController]
    [Route("api/Test/v1")]
    public class EventController : ControllerBase
    {

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }
    }
}