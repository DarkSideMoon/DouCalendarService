using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DouCalendarService.WebAPI.Controllers
{
    [ApiController]
    [Route("calendar")]
    [Produces("application/json")]
    public class CalendarController : ControllerBase
    {
        public CalendarController()
        {

        }

        [HttpGet]
        [Route("events")]
        public async Task<IActionResult> GetEvent()
        {
            return Ok();
        }
    }
}
