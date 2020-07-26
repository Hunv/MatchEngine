using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchEngine.DatabaseModel;
using MatchLibrary.PotentialModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (var dbContext = new MyDbContext())
            {
                var js = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                };
                var json = JsonConvert.SerializeObject(dbContext.Players, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Player newPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Players.Add(newPlayer);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Player editPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                var player = dbContext.Players.SingleOrDefault(x => x.Id == editPlayer.Id);
                player.Birthday = editPlayer.Birthday;
                player.Club = editPlayer.Club;
                player.DisplayName = editPlayer.DisplayName;
                player.FederationNumber = editPlayer.FederationNumber;
                player.FirstName = editPlayer.FirstName;
                player.HealthCertificateExpiration = editPlayer.HealthCertificateExpiration;
                player.LastName = editPlayer.LastName;
                player.Nationality = editPlayer.Nationality;
                player.RefereeLevel = editPlayer.RefereeLevel;
                player.RefereeLevelExpiration = editPlayer.RefereeLevelExpiration;
                player.Sex = editPlayer.Sex;
                player.ShortName = editPlayer.ShortName;

                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Player deletePlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                var player = dbContext.Players.SingleOrDefault(x => x.Id == deletePlayer.Id);
                dbContext.Players.Remove(player);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
    }
}
