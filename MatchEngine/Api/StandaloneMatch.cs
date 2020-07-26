using MatchEngine.DatabaseModel;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public class StandaloneMatch
    {
        /// <summary>
        /// Gets the whole standalone match including all data
        /// </summary>
        /// <returns></returns>
        public static string GetStandaloneMatchSerialized()
        {
            using (var dbContext = new MyDbContext())
            {
                var json = JsonConvert.SerializeObject(dbContext.StandaloneMatch.Include("Teams"), Helper.GetJsonSerializer());
                return json;                
            }
        }

        /// <summary>
        /// Gets the time left of a standalone match
        /// </summary>
        /// <returns>time left in seconds</returns>
        public static string GetStandaloneMatchTimeSerialized()
        {
            using (var dbContext = new MyDbContext())
            {
                var match = dbContext.StandaloneMatch;
                var timeleft = 0;
                if (match.Count() > 0)
                    timeleft = match.First().SecondsLeft;

                var json = JsonConvert.SerializeObject(timeleft, Helper.GetJsonSerializer());
                return json;
            }
        }

        /// <summary>
        /// Sets the time left of a standalone match
        /// </summary>
        /// <param name="timeLeft"></param>
        public static void SetStandaloneMatchTime(int timeLeft)
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.StandaloneMatch.First().SecondsLeft = timeLeft;
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the current scores of all teams of a standalone match
        /// </summary>
        /// <returns>array of goals, ordered by the teamIndex</returns>
        public static string GetStandaloneMatchGoalsSerialized()
        {
            using (var dbContext = new MyDbContext())
            {
                var teams = dbContext.StandaloneTeams.Select(x => x.Score);
                var json = JsonConvert.SerializeObject(teams, Helper.GetJsonSerializer());
                return json;
            }
        }

        /// <summary>
        /// Modifies the goals of a standalone match for a team by the given socre parameter
        /// </summary>
        /// <param name="teamIndex">Index of the team</param>
        /// <param name="score">Modifier of the current scores</param>
        public static void SetStandaloneMatchGoals(int teamIndex, int score)
        {
            using (var dbContext = new MyDbContext())
            {
                var team = dbContext.StandaloneTeams.Take(teamIndex + 1).AsEnumerable().Last();
                team.Score += score;
                    
                dbContext.SaveChanges();
            }
        }


        /// <summary>
        /// Modifies the goals of a standalone match for a team by the given socre parameter
        /// </summary>
        /// <param name="teamIndex">Index of the team</param>
        /// <param name="score">Modifier of the current scores</param>
        public static void ResetStandaloneMatch()
        {
            using (var dbContext = new MyDbContext())
            {
                dbContext.StandaloneTeams.RemoveRange(dbContext.StandaloneTeams);
                dbContext.StandaloneTeams.Add(new StandaloneTeam() { Score = 0 });
                dbContext.StandaloneTeams.Add(new StandaloneTeam() { Score = 0 });

                SetStandaloneMatchTime(0);
                dbContext.SaveChanges();
            }
        }
    }
}
