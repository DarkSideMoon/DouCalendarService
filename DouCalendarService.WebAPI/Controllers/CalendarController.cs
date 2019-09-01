using DouCalendarService.Contracts.Types;
using DouCalendarService.Service.Dou;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.Controllers
{
    [ApiController]
    [Route("calendar")]
    [Produces("application/json")]
    public class CalendarController : ControllerBase
    {
        private readonly IDouService _douService;

        public CalendarController(IDouService douService)
        {
            _douService = douService;
        }

        [HttpGet]
        [Route("event/{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("events/day/{date}")]
        public async Task<IActionResult> GetEventsOnDay(string date)
        {
            var result = await _douService.GetEventsOnDay(date);

            return Ok(result);
        }

        [HttpGet]
        [Route("events/city/{location}")]
        public async Task<IActionResult> GetEventsByLocation(LocationType location)
        {
            var result = await _douService.GetEventsByLocation(location);

            return Ok(result);
        }

        [HttpGet]
        [Route("events/topic/{topic}")]
        public async Task<IActionResult> GetEventsByTopic(TopicType topic)
        {
            var result = await _douService.GetEventsByTopic(topic);

            return Ok(result);
        }
    }
}
