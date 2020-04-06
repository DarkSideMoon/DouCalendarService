using DouCalendarService.Contracts.Common;
using DouCalendarService.Service.Dou;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("calendar")]
    [Produces("application/json")]
    public class CalendarController : BaseController
    {
        private readonly IDouService _douService;

        public CalendarController(IDouService douService)
        {
            _douService = douService;
        }

        /// <summary>
        /// Get google link to add in calendar
        /// </summary>
        /// <param name="id">Id of event</param>
        /// <returns>Return link to google calendar of find event</returns>
        /// <response code="200">Return find event</response>
        /// <response code="404">Event not found</response>  
        [HttpGet]
        [Route("google/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetGoogleCalendarLinkById(string id)
        {
            LogRequestInformation(id);

            var result = await _douService.CreateGoogleLink(id);

            LogResponseInformation(result);
            return Ok(result);
        }
    }
}
