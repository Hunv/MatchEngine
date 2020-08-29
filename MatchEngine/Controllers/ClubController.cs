using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MatchEngine.DatabaseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ILogger<ClubController> _logger;

        public ClubController(ILogger<ClubController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all Clubs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClubList()
        {
            _logger.LogDebug("{0}: Get ClubList", Request.HttpContext.Connection.RemoteIpAddress);

            var json = Api.ApiClub.GetClubList();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got ClubList JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }


        /// <summary>
        /// Gets a Club Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetClub(int id)
        {
            _logger.LogDebug("{0}: Get Club {1}", Request.HttpContext.Connection.RemoteIpAddress, id);

            var json = Api.ApiClub.GetClub(id);
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got Club ID {1} JSON {2}", Request.HttpContext.Connection.RemoteIpAddress, id, json);
            return result;
        }

        /// <summary>
        /// Modify an existing Club
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> SetClub(
            [FromBody] MatchLibrary.ApiModel.DtoClub Club
            )
        {
            _logger.LogDebug("{0}: Set Club {1}", Request.HttpContext.Connection.RemoteIpAddress, Club.Id);

            await Api.ApiClub.SetClub(Club);
            
            _logger.LogDebug("{0}: Set Club ID {1}", Request.HttpContext.Connection.RemoteIpAddress, Club.Id);
            return new OkResult(); ;
        }

        /// <summary>
        /// Add a new Club
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> NewClub(
            [FromBody] MatchLibrary.ApiModel.DtoClub Club
            )
        {
            _logger.LogDebug("{0}: New Club", Request.HttpContext.Connection.RemoteIpAddress);

            await Api.ApiClub.NewClub(Club);

            _logger.LogDebug("{0}: New Club", Request.HttpContext.Connection.RemoteIpAddress);
            return new OkResult(); ;
        }
    }
}
