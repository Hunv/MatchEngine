using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MatchEngine.Database;
using MatchLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ILogger<TournamentController> _logger;

        public TournamentController(ILogger<TournamentController> logger)
        {
            _logger = logger;
        }

        #region Tournament
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
                var json = JsonConvert.SerializeObject(dbContext.Tournaments, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Tournament newTournament)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.Tournaments.Add(newTournament);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Tournament editTournament)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournament = dbContext.Tournaments.SingleOrDefault(x => x.Id == editTournament.Id);
                tournament.EndDate = editTournament.EndDate;
                tournament.Location = editTournament.Location;
                tournament.Name = editTournament.Name;
                tournament.StartDate = editTournament.StartDate;
                tournament.TeamList = editTournament.TeamList;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Tournament deleteTournament)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournament = dbContext.Tournaments.SingleOrDefault(x => x.Id == deleteTournament.Id);
                dbContext.Tournaments.Remove(tournament);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion


        #region TournamentPlayer
        [HttpGet]
        [Route("player")]
        public IActionResult GetPlayer()
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
                var json = JsonConvert.SerializeObject(dbContext.TournamentPlayers, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        [Route("player")]
        public IActionResult PostPlayer([FromBody]TournamentPlayer newTournamentPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.TournamentPlayers.Add(newTournamentPlayer);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        [Route("player")]
        public IActionResult PutPlayer([FromBody]TournamentPlayer editTournamentPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournamentPlayer = dbContext.TournamentPlayers.SingleOrDefault(x => x.Id == editTournamentPlayer.Id);
                tournamentPlayer.BasePlayer = editTournamentPlayer.BasePlayer;
                tournamentPlayer.Number = editTournamentPlayer.Number;
                tournamentPlayer.Team = editTournamentPlayer.Team;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        [Route("player")]
        public IActionResult DeletePlayer([FromBody]TournamentPlayer deleteTournamentPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournamentPlayer = dbContext.TournamentPlayers.SingleOrDefault(x => x.Id == deleteTournamentPlayer.Id);
                dbContext.TournamentPlayers.Remove(deleteTournamentPlayer);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion


        #region TournamentTeam
        [HttpGet]
        [Route("team")]
        public IActionResult GetTeam()
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
                var json = JsonConvert.SerializeObject(dbContext.TournamentTeams, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        [Route("team")]
        public IActionResult PostTeam([FromBody]TournamentTeam newTournamentTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.TournamentTeams.Add(newTournamentTeam);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        [Route("team")]
        public IActionResult PutTeam([FromBody]TournamentTeam editTournamentTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournamentTeam = dbContext.TournamentTeams.SingleOrDefault(x => x.Id == editTournamentTeam.Id);
                tournamentTeam.Captain = editTournamentTeam.Captain;
                tournamentTeam.Coach = editTournamentTeam.Coach;
                tournamentTeam.CoCaptain = editTournamentTeam.CoCaptain;
                tournamentTeam.Displayname = editTournamentTeam.Displayname;
                tournamentTeam.Name = editTournamentTeam.Name;
                tournamentTeam.PlayerList = editTournamentTeam.PlayerList;
                tournamentTeam.Shortname = editTournamentTeam.Shortname;
                tournamentTeam.Tournament = editTournamentTeam.Tournament;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        [Route("team")]
        public IActionResult DeleteTeam([FromBody]TournamentTeam deleteTournamentTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                var tournamentTeam = dbContext.TournamentTeams.SingleOrDefault(x => x.Id == deleteTournamentTeam.Id);
                dbContext.TournamentTeams.Remove(deleteTournamentTeam);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion
    }
}
