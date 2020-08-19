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
    public class TournamentController : ControllerBase
    {
        private readonly ILogger<TournamentController> _logger;

        public TournamentController(ILogger<TournamentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all Matches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTournamentList()
        {
            _logger.LogDebug("{0}: Get TournamentList", Request.HttpContext.Connection.RemoteIpAddress);

            var json = Api.ApiTournament.GetTournamentList();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got TournamentList JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }


        /// <summary>
        /// Gets all Matches of a Tournament
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/matchlist")]
        public IActionResult GetTournamentMatches(int id)
        {
            _logger.LogDebug("{0}: Get Tournament Matches {1}", Request.HttpContext.Connection.RemoteIpAddress, id);

            var json = Api.ApiTournament.GetTournamentMatches(id);
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got Tournament Matches ID {1} JSON {2}", Request.HttpContext.Connection.RemoteIpAddress, id, json);
            return result;
        }

        /// <summary>
        /// Gets all Tournamentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetTournament(int id)
        {
            _logger.LogDebug("{0}: Get Tournament {1}", Request.HttpContext.Connection.RemoteIpAddress, id);

            var json = Api.ApiTournament.GetTournament(id);
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got Tournament ID {1} JSON {2}", Request.HttpContext.Connection.RemoteIpAddress, id, json);
            return result;
        }

        /// <summary>
        /// Modify an existing Tournament
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> SetTournament(
            [FromBody] MatchLibrary.ApiModel.DtoTournament tournament
            )
        {
            _logger.LogDebug("{0}: Set Tournament {1}", Request.HttpContext.Connection.RemoteIpAddress, tournament.Id);

            await Api.ApiTournament.SetTournament(tournament);
            
            _logger.LogDebug("{0}: Set Tournament ID {1}", Request.HttpContext.Connection.RemoteIpAddress, tournament.Id);
            return new OkResult(); ;
        }

        /// <summary>
        /// Add a new Tournament
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> NewTournament(
            [FromBody] MatchLibrary.ApiModel.DtoTournament tournament
            )
        {
            _logger.LogDebug("{0}: New Tournament", Request.HttpContext.Connection.RemoteIpAddress);

            await Api.ApiTournament.NewTournament(tournament);

            _logger.LogDebug("{0}: New Tournament", Request.HttpContext.Connection.RemoteIpAddress);
            return new OkResult(); ;
        }
    }
}
