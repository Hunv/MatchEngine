using MatchEngine.DatabaseModel;
using MatchLibrary;
using MatchLibrary.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public static class ApiTeam
    {
        /// <summary>
        /// Get a list of all teams
        /// </summary>
        public static string GetTeamList()
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = new List<DtoTeam>();
                foreach (var aTeam in dbContext.Teams)
                    dto.Add(aTeam.ToDto());

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        /// <summary>
        /// Get a teams
        /// </summary>
        public static string GetTeam(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Teams.SingleOrDefault(x => x.Id == id);

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        /// <summary>
        /// Get a teams
        /// </summary>
        public static async Task SetTeam(DtoTeam team)
        {
            using (var dbContext = new MyDbContext())
            {
                var tm = dbContext.Teams.SingleOrDefault(x => x.Id == team.Id);
                if (tm != null)
                {
                    if (team.Club != null)
                        tm.Club = team.Club;

                    if (team.Coach != null)
                        tm.Coach = team.Coach;

                    if (team.Name != null)
                        tm.Name = team.Name;

                    if (team.Notes != null)
                        tm.Notes = team.Notes;

                    if (team.Shortcut != null)
                        tm.Shortcut = team.Shortcut;

                    if (team.Shortname != null)
                        tm.Shortname = team.Shortname;

                    if (team.Teamcaptain != null)
                        tm.Teamcaptain = team.Teamcaptain;

                    if (team.ViceTeamcaptain != null)
                        tm.ViceTeamcaptain = team.ViceTeamcaptain;

                    if (team.MatchIdList != null)
                    {
                        tm.MatchList = dbContext.Teams2Matches.Where(x => team.MatchIdList.Contains(x.MatchId)).ToList();
                    }

                    if (team.TournamentIdList != null)
                    {
                        tm.TournamentList = dbContext.Teams2Tournaments.Where(x => team.TournamentIdList.Contains(x.TournamentId)).ToList();
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async static Task NewTeam(DtoTeam dtoTeam)
        {
            using (var dbContext = new MyDbContext())
            {
                var team = new Team(dtoTeam);
                
                if (dtoTeam.MatchIdList != null)
                    team.MatchList = dbContext.Teams2Matches.Where(x => dtoTeam.MatchIdList.Contains(x.MatchId)).ToList();

                if (dtoTeam.TournamentIdList != null)
                    team.TournamentList = dbContext.Teams2Tournaments.Where(x => dtoTeam.TournamentIdList.Contains(x.TournamentId)).ToList();

                dbContext.Teams.Add(team);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
