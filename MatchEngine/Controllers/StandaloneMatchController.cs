using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchEngine.DatabaseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandaloneMatchController : ControllerBase
    {
        private readonly ILogger<StandaloneMatchController> _logger;

        public StandaloneMatchController(ILogger<StandaloneMatchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("{0}: Get StandaloneMatch", Request.HttpContext.Connection.RemoteIpAddress);
            //Get the Standalone Match details
            var json = Api.StandaloneMatch.GetStandaloneMatchSerialized();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got StandaloneMatch JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }


        /// <summary>
        /// Resets the match. Stops the time, setting score to 0
        /// </summary>
        /// <returns></returns>
        [HttpPut("reset", Name = "ResetMatch")]
        public IActionResult PutStart(int teamIndex, int score)
        {
            _logger.LogDebug("{0}: Put StandaloneMatch Reset", Request.HttpContext.Connection.RemoteIpAddress);

            var json = Api.StandaloneMatch.SetStandaloneMatchGoals(teamIndex, score);

            return new OkResult();
        }
    }
}
