using DouCalendarService.Contracts.Types;
using DouCalendarService.Service.Dou;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.Controllers
{
    [ApiController]
    [Route("event")]
    [Produces("application/json")]
    public class EventController : ControllerBase
    {
        private readonly IDouService _douService;

        public EventController(IDouService douService)
        {
            _douService = douService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEventById(string id)
        {
            var result = await _douService.GetEventById(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("day/{date}")]
        public async Task<IActionResult> GetEventsOnDay(string date)
        {
            var result = await _douService.GetEventsOnDay(date);

            return Ok(result);
        }

        [HttpGet]
        [Route("city/{location}")]
        public async Task<IActionResult> GetEventsByLocation(LocationType location)
        {
            var result = await _douService.GetEventsByLocation(location);

            return Ok(result);
        }

        [HttpGet]
        [Route("topic/{topic}")]
        public async Task<IActionResult> GetEventsByTopic(TopicType topic)
        {
            var result = await _douService.GetEventsByTopic(topic);

            return Ok(result);
        }
    }
}
