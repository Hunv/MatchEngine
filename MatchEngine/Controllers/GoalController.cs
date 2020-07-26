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
    public class GoalController : ControllerBase
    {
        private readonly ILogger<GoalController> _logger;

        public GoalController(ILogger<GoalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("{0}: Get StandaloneMatch Goals", Request.HttpContext.Connection.RemoteIpAddress);
            //Get the Standalone Match details
            var json = Api.StandaloneMatch.GetStandaloneMatchGoalsSerialized();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got StandaloneMatch Goals JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }

        /// <summary>
        /// Starts the countdown of the time
        /// </summary>
        /// <returns></returns>
        [HttpPut("add", Name = "AddScore")]
        public IActionResult PutStart(int teamIndex, int score)
        {
            _logger.LogDebug("{0}: Put StandaloneMatch Goals Adding {1} Scores", Request.HttpContext.Connection.RemoteIpAddress, score);

            Api.StandaloneMatch.SetStandaloneMatchGoals(teamIndex, score);

            return new OkResult();
        }
    }
}
