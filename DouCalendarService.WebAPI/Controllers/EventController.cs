using DouCalendarService.Contracts.Common;
using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Types;
using DouCalendarService.Service.Dou;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.Controllers
{
    [ApiController]
    [Route("event")]
    [Produces("application/json")]
    public class EventController : BaseController
    {
        private readonly IDouService _douService;

        public EventController(IDouService douService)
        {
            _douService = douService;
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="id">Id of event</param>
        /// <returns>Return find event</returns>
        /// <response code="200">Return find event</response>
        /// <response code="404">Event not found</response>    
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Event), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetEventById(string id)
        {
            LogRequestInformation(id);

            var result = await _douService.GetEventById(id);

            LogResponseInformation(result);
            return Ok(result);
        }

        /// <summary>
        /// Get events by day
        /// </summary>
        /// <param name="date">Day of event</param>
        /// <returns></returns>
        /// <response code="200">Return find events by day</response>
        [HttpGet]
        [Route("day/{date}")]
        [ProducesResponseType(typeof(IEnumerable<ShortEvent>), 200)]
        public async Task<IActionResult> GetEventsOnDay(string date)
        {
            LogRequestInformation(date);

            var result = await _douService.GetEventsOnDay(date);

            LogResponseInformation(result);
            return Ok(result);
        }

        /// <summary>
        /// Get events by location
        /// </summary>
        /// <param name="location">Location of event</param>
        /// <returns></returns>
        /// <response code="200">Return find events by location</response>
        [HttpGet]
        [Route("city/{location}")]
        [ProducesResponseType(typeof(IEnumerable<ShortEvent>), 200)]
        public async Task<IActionResult> GetEventsByLocation(LocationType location)
        {
            LogRequestInformation(location.ToString());

            var result = await _douService.GetEventsByLocation(location);

            LogResponseInformation(result);
            return Ok(result);
        }

        /// <summary>
        /// Get events by topic
        /// </summary>
        /// <param name="topic">Topic of event</param>
        /// <returns></returns>
        /// <response code="200">Return find events by topic</response>
        [HttpGet]
        [Route("topic/{topic}")]
        [ProducesResponseType(typeof(IEnumerable<ShortEvent>), 200)]
        public async Task<IActionResult> GetEventsByTopic(TopicType topic)
        {
            LogRequestInformation(topic.ToString());

            var result = await _douService.GetEventsByTopic(topic);

            LogResponseInformation(result);
            return Ok(result);
        }
    }
}
