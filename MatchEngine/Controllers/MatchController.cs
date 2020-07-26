using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MatchEngine.Database;
using MatchLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MatchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;

        public MatchController(ILogger<MatchController> logger)
        {
            _logger = logger;
        }

        #region Match
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
                var json = JsonConvert.SerializeObject(dbContext.MatchInfos, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchInfos.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]MatchInfo newMatchInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchInfos.Add(newMatchInfo);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult Put([FromBody]MatchInfo editMatchInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchInfo = dbContext.MatchInfos.SingleOrDefault(x => x.Id == editMatchInfo.Id);
                matchInfo.CurrentHalftime = editMatchInfo.CurrentHalftime;
                matchInfo.IsMatchRunning = editMatchInfo.IsMatchRunning;
                matchInfo.MatchConfiguration = editMatchInfo.MatchConfiguration;
                matchInfo.PlannedStartTime = editMatchInfo.PlannedStartTime;
                matchInfo.RefereeList = editMatchInfo.RefereeList;
                matchInfo.RemainingSecondsHalftime = editMatchInfo.RemainingSecondsHalftime;
                matchInfo.StartTime = editMatchInfo.StartTime;
                matchInfo.Team1 = editMatchInfo.Team1;
                matchInfo.Team1Score = editMatchInfo.Team1Score;
                matchInfo.Team2 = editMatchInfo.Team2;
                matchInfo.Team2Score = editMatchInfo.Team2Score;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]MatchInfo deleteMatchInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchInfo = dbContext.MatchInfos.SingleOrDefault(x => x.Id == deleteMatchInfo.Id);
                dbContext.MatchInfos.Remove(matchInfo);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion

        #region MatchTeam
        [HttpGet]
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
                var json = JsonConvert.SerializeObject(dbContext.MatchTeams, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchTeams.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult PostTeam([FromBody]MatchTeam newMatchTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchTeams.Add(newMatchTeam);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult PutTeam([FromBody]MatchTeam editMatchTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchTeam = dbContext.MatchTeams.SingleOrDefault(x => x.Id == editMatchTeam.Id);
                matchTeam.Team = editMatchTeam.Team;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult DeleteTeam([FromBody]MatchTeam deleteMatchTeamInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchTeam = dbContext.MatchTeams.SingleOrDefault(x => x.Id == deleteMatchTeamInfo.Id);
                dbContext.MatchTeams.Remove(matchTeam);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion

        #region MatchPlayer
        [HttpGet]
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
                var json = JsonConvert.SerializeObject(dbContext.MatchPlayers, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchPlayers.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult PostPlayer([FromBody]MatchPlayer newMatchPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchPlayers.Add(newMatchPlayer);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult PutPlayer([FromBody]MatchPlayer editMatchPlayer)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchPlayer = dbContext.MatchPlayers.SingleOrDefault(x => x.Id == editMatchPlayer.Id);
                matchPlayer.Comment = editMatchPlayer.Comment;
                matchPlayer.IsPlaying = editMatchPlayer.IsPlaying;
                matchPlayer.RefereeMatch = editMatchPlayer.RefereeMatch;
                matchPlayer.Player = editMatchPlayer.Player;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult DeletePlayer([FromBody]MatchPlayer deleteMatchPlayerInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchPlayer = dbContext.MatchPlayers.SingleOrDefault(x => x.Id == deleteMatchPlayerInfo.Id);
                dbContext.MatchPlayers.Remove(matchPlayer);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion

        #region MatchHalftime
        [HttpGet]
        public IActionResult GetHalftime()
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
                var json = JsonConvert.SerializeObject(dbContext.MatchHalftimes, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetHalftime(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchHalftimes.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult PostHalftime([FromBody]MatchHalftime newMatchHalftime)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchHalftimes.Add(newMatchHalftime);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult PutHalftime([FromBody]MatchHalftime editMatchHalftime)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchHalftime = dbContext.MatchHalftimes.SingleOrDefault(x => x.Id == editMatchHalftime.Id);
                matchHalftime.DurationSeconds = editMatchHalftime.DurationSeconds;
                matchHalftime.BreakSeconds = editMatchHalftime.BreakSeconds;
                matchHalftime.IsOvertime = editMatchHalftime.IsOvertime;
                matchHalftime.Match = editMatchHalftime.Match;
                matchHalftime.Name = editMatchHalftime.Name;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult DeleteHalftime([FromBody]MatchHalftime deleteMatchHalftimeInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchHalftime = dbContext.MatchHalftimes.SingleOrDefault(x => x.Id == deleteMatchHalftimeInfo.Id);
                dbContext.MatchHalftimes.Remove(matchHalftime);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion

        #region MatchGoal
        [HttpGet]
        public IActionResult GetGoal()
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
                var json = JsonConvert.SerializeObject(dbContext.MatchGoals, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetGoal(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchGoals.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult PostGoal([FromBody]MatchGoal newMatchGoal)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchGoals.Add(newMatchGoal);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult PutGoal([FromBody]MatchGoal editMatchGoal)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchGoal = dbContext.MatchGoals.SingleOrDefault(x => x.Id == editMatchGoal.Id);
                matchGoal.MatchTeam1 = editMatchGoal.MatchTeam1;
                matchGoal.MatchTeam2 = editMatchGoal.MatchTeam2;
                matchGoal.ScoreAmount = editMatchGoal.ScoreAmount;
                matchGoal.Timestamp = editMatchGoal.Timestamp;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult DeleteGoal([FromBody]MatchGoal deleteMatchGoalInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchGoal = dbContext.MatchGoals.SingleOrDefault(x => x.Id == deleteMatchGoalInfo.Id);
                dbContext.MatchGoals.Remove(matchGoal);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion

        #region MatchConfiguration
        [HttpGet]
        public IActionResult GetConfiguration()
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
                var json = JsonConvert.SerializeObject(dbContext.MatchConfigurations, js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetConfiguration(int id)
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
                var json = JsonConvert.SerializeObject(dbContext.MatchConfigurations.SingleOrDefault(x => x.Id == id), js);
                var result = new OkObjectResult(json);
                return result;
            }

        }

        [HttpPost]
        public IActionResult PostConfiguration([FromBody]MatchConfiguration newMatchConfiguration)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.MatchConfigurations.Add(newMatchConfiguration);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpPut]
        public IActionResult PutConfiguration([FromBody]MatchConfiguration editMatchConfiguration)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchConfiguration = dbContext.MatchConfigurations.SingleOrDefault(x => x.Id == editMatchConfiguration.Id);
                matchConfiguration.DurationTimeoutSeconds = editMatchConfiguration.DurationTimeoutSeconds;
                matchConfiguration.Halftimes = editMatchConfiguration.Halftimes;
                matchConfiguration.ScoreGoalType1 = editMatchConfiguration.ScoreGoalType1;
                matchConfiguration.ScoreGoalType2 = editMatchConfiguration.ScoreGoalType2;
                matchConfiguration.ScoreGoalType3 = editMatchConfiguration.ScoreGoalType3;
                dbContext.SaveChanges();
            }
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult DeleteConfiguration([FromBody]MatchConfiguration deleteMatchConfigurationInfo)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchConfiguration = dbContext.MatchConfigurations.SingleOrDefault(x => x.Id == deleteMatchConfigurationInfo.Id);
                dbContext.MatchConfigurations.Remove(matchConfiguration);
                dbContext.SaveChanges();
            }
            return new OkResult();
        }
        #endregion
    }
}
