using DouCalendarService.Contracts.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DouCalendarService.WebAPI.Controllers
{
    [ApiController]
    [Route("types")]
    [Produces("application/json")]
    public class TypesController : BaseController
    {
        /// <summary>
        /// Get topic types
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Return list of available topic</response>
        [HttpGet]
        [Route("topic")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IActionResult GetTopicTypes()
        {
            var topics = Enum.GetNames(typeof(TopicType));
            return Ok(topics);
        }

        /// <summary>
        /// Get location types
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Return list of available topic</response>
        [HttpGet]
        [Route("location")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IActionResult GetLocationTypes()
        {
            var topics = Enum.GetNames(typeof(LocationType));
            return Ok(topics);
        }
    }
}
