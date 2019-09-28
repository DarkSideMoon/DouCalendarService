using DouCalendarService.Contracts.Common;
using DouCalendarService.Service.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DouCalendarService.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("security")]
    [Produces("application/json")]
    public class SecurityController : BaseController
    {
        private readonly ITokenManagementService _tokenManagementService;

        public SecurityController(ITokenManagementService tokenManagementService)
        {
            _tokenManagementService = tokenManagementService;
        }

        /// <summary>
        /// Generate token by credentials
        /// </summary>
        /// <returns>Return find event</returns>
        /// <response code="200">Return token</response>
        /// <response code="403">Forbidden</response>
        [HttpGet]
        [Route("token")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 403)]
        public ActionResult<string> GenerateToken()
        {
            LogRequestInformation("Generate token for {}");

            var token = _tokenManagementService.GenerateToken();

            LogResponseInformation("Token for {} was created successfully");
            return Ok(token);
        }
    }
}
