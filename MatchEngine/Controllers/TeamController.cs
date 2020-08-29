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
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TournamentController> _logger;

        public TeamController(ILogger<TournamentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all Teams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTeamList()
        {
            _logger.LogDebug("{0}: Get TeamList", Request.HttpContext.Connection.RemoteIpAddress);

            var json = Api.ApiTeam.GetTeamList();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got TeamList JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }


        /// <summary>
        /// Gets a Team Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            _logger.LogDebug("{0}: Get Team {1}", Request.HttpContext.Connection.RemoteIpAddress, id);

            var json = Api.ApiTeam.GetTeam(id);
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got Team ID {1} JSON {2}", Request.HttpContext.Connection.RemoteIpAddress, id, json);
            return result;
        }

        /// <summary>
        /// Modify an existing Team
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> SetTeam(
            [FromBody] MatchLibrary.ApiModel.DtoTeam Team
            )
        {
            _logger.LogDebug("{0}: Set Team {1}", Request.HttpContext.Connection.RemoteIpAddress, Team.Id);

            await Api.ApiTeam.SetTeam(Team);
            
            _logger.LogDebug("{0}: Set Team ID {1}", Request.HttpContext.Connection.RemoteIpAddress, Team.Id);
            return new OkResult(); ;
        }

        /// <summary>
        /// Add a new Team
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> NewTeam(
            [FromBody] MatchLibrary.ApiModel.DtoTeam Team
            )
        {
            _logger.LogDebug("{0}: New Team", Request.HttpContext.Connection.RemoteIpAddress);

            await Api.ApiTeam.NewTeam(Team);

            _logger.LogDebug("{0}: New Team", Request.HttpContext.Connection.RemoteIpAddress);
            return new OkResult(); ;
        }
    }
}
