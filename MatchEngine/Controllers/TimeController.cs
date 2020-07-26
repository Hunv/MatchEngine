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
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("{0}: Get StandaloneMatch Time", Request.HttpContext.Connection.RemoteIpAddress);
            //Get the Standalone Match details
            var json = Api.StandaloneMatch.GetStandaloneMatchTimeSerialized();
            var result = new OkObjectResult(json);

            _logger.LogDebug("{0}: Got StandaloneMatch Time JSON {1}", Request.HttpContext.Connection.RemoteIpAddress, json);
            return result;
        }

        /// <summary>
        /// Starts the countdown of the time
        /// </summary>
        /// <returns></returns>
        [HttpPut("start", Name = "StartMatch")]
        public IActionResult PutStart()
        {
            _logger.LogDebug("{0}: Put StandaloneMatch Time START", Request.HttpContext.Connection.RemoteIpAddress);

            //Start the timer to count down the time
            MatchLogic.StandaloneMatch.Start();

            return new OkResult();
        }

        /// <summary>
        /// Stops the countdown of the time
        /// </summary>
        /// <returns></returns>
        [HttpPut("stop", Name = "StopMatch")]
        public IActionResult PutStop()
        {
            _logger.LogDebug("{0}: Put StandaloneMatch Time STOP", Request.HttpContext.Connection.RemoteIpAddress);

            //Stop the timer to count down the time
            MatchLogic.StandaloneMatch.Stop();

            return new OkResult();
        }


        /// <summary>
        /// Set the time left in seconds of a Standalone Match
        /// </summary>
        /// <param name="left"></param>
        /// <returns></returns>
        [HttpPut("set", Name = "SetTime")]
        public IActionResult PutStop(int left)
        {
            _logger.LogDebug("{0}: Put StandaloneMatch Time to {left}", Request.HttpContext.Connection.RemoteIpAddress);
            //Set the time left (in seconds)
            Api.StandaloneMatch.SetStandaloneMatchTime(left);
            
            return new OkResult();
        }
    }
}
