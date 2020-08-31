using MatchEngine.DatabaseModel;
using MatchEngine.MatchLogic;
using MatchLibrary;
using MatchLibrary.ApiModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public static class ApiMatch
    {
        public static string GetMatchList()
        {
            using(var dbContext = new MyDbContext())
            {
                var dto = new List<DtoMatch>();
                foreach(var aMatch in dbContext.Matches.Include("Tournament"))
                    dto.Add(aMatch.ToDto());

                var json = JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
                return json;
            }
        }


        public static string GetLiveMatchList()
        {
            using (var dbContext = new MyDbContext())
            {
                var ongoingMatchIds = MatchCore.OngoingMatches.Select(x => x.MatchId);
                var dto = new List<DtoMatch>();                    

                foreach (var aMatch in dbContext.Matches.Include("Tournament").Where(x => ongoingMatchIds.Contains(x.Id)))
                    dto.Add(aMatch.ToDto());

                var json = JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
                return json;
            }
        }

        public static string GetMatch(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.SingleOrDefault(x => x.Id == id);
                if (dto != null)
                    return JsonConvert.SerializeObject(dto.ToDto(), Helper.GetJsonSerializer());                
                else
                    return "";
            }
        }

        public async static Task SetMatch(DtoMatch match)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.SingleOrDefault(x => x.Id == match.Id);
                if (dto != null)
                {
                    if (match.ScoreTeam1.HasValue)
                        dto.ScoreTeam1 = match.ScoreTeam1.Value;

                    if (match.ScoreTeam2.HasValue)
                        dto.ScoreTeam2 = match.ScoreTeam2.Value;

                    if (!string.IsNullOrEmpty(match.NameTeam1))
                        dto.NameTeam1 = match.NameTeam1;

                    if (!string.IsNullOrEmpty(match.NameTeam2))
                        dto.NameTeam2 = match.NameTeam2;

                    if (match.TimeLeftSeconds.HasValue)
                        dto.TimeLeftSeconds = match.TimeLeftSeconds.Value;

                    if (match.TournamentId.HasValue)
                        dto.Tournament = dbContext.Tournaments.SingleOrDefault(x => x.Id == match.TournamentId);

                    if (match.Team1Id != null)
                        dto.Team1Id = match.Team1Id.Value;

                    if (match.Team2Id != null)
                        dto.Team2Id = match.Team2Id.Value;
                    
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async static Task NewMatch(DtoMatch match)
        {
            using (var dbContext = new MyDbContext())
            {
                var newMatch = new Match()
                {
                    ScoreTeam1 = match.ScoreTeam1 ?? 0,
                    ScoreTeam2 = match.ScoreTeam2 ?? 0,
                    NameTeam1 = match.NameTeam1,
                    NameTeam2 = match.NameTeam2,
                    TimeLeftSeconds = match.TimeLeftSeconds ?? 0,
                    Team1Id = match.Team1Id ?? 0,
                    Team2Id = match.Team2Id ?? 0
                };
                if (match.TournamentId != 0)
                {                    
                    newMatch.Tournament = dbContext.Tournaments.SingleOrDefault(x => x.Id == match.TournamentId);
                }

                dbContext.Matches.Add(newMatch);

                await dbContext.SaveChangesAsync();
            }
        }


        public static string GetMatchTime(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.SingleOrDefault(x => x.Id == id);
                if (dto != null)
                    return JsonConvert.SerializeObject(dto.TimeLeftSeconds, Helper.GetJsonSerializer());
                else
                    return "";
            }
        }

        public static async Task SetMatchTime(int id, int timeleft)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.SingleOrDefault(x => x.Id == id);
                if (dto != null)
                {
                    dto.TimeLeftSeconds = timeleft;
                    await dbContext.SaveChangesAsync();
                }
            }

        }

        public static void StartMatchtime(int id)
        {
            //If match not already exist, create a new one
            if (!MatchCore.OngoingMatches.Any(x => x.MatchId == id))
            {
                MatchCore.AddOngoingMatch(new MatchHandler(id));
            }
            
            //Start the Match
            MatchCore.OngoingMatches.Single(x => x.MatchId == id).Start();
        }

        public static void StopMatchtime(int id)
        {
            var match = MatchCore.OngoingMatches.SingleOrDefault(x => x.MatchId == id);
            if (match != null)
                match.Stop();
        }

        public static void EndMatch(int id)
        {
            var match = MatchCore.OngoingMatches.SingleOrDefault(x => x.MatchId == id);
            if (match != null)
                MatchCore.OngoingMatches.Remove(match);
        }


        public static async Task SetMatchGoal(int matchId, int teamId, int amount)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.SingleOrDefault(x => x.Id == matchId);
                if (dto != null)
                {
                    if (teamId == 0)
                        dto.ScoreTeam1 += amount;
                    else if (teamId == 1)
                        dto.ScoreTeam2 += amount;

                    await dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
