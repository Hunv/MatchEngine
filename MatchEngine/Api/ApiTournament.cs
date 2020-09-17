﻿using MatchEngine.DatabaseModel;
using MatchLibrary;
using MatchLibrary.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchEngine.Api
{
    public static class ApiTournament
    {
        public static string GetTournamentList()
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = new List<DtoTournament>();
                foreach (var aTournament in dbContext.Tournaments)
                    dto.Add(aTournament.ToDto());

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        public static string GetTournament(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Tournaments.SingleOrDefault(x => x.Id == id);
                if (dto == null)
                    return "";

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        public static string GetTournamentMatches(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Matches.Where(x => x.Tournament.Id == id);
                if (dto == null)
                    return "";

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }
                
        public async static Task SetTournament(DtoTournament tournament)
        {
            using (var dbContext = new MyDbContext())
            {
                var tmt = dbContext.Tournaments.SingleOrDefault(x => x.Id == tournament.Id);
                if (tmt != null)
                {
                    if (tournament.City != null)
                        tmt.City = tournament.City;

                    if (tournament.Date.HasValue)
                        tmt.Date = tournament.Date.Value;

                    if (tournament.Location != null)
                        tmt.Location = tournament.Location;

                    if (tournament.Name != null)
                        tmt.Name = tournament.Name;

                    if (tournament.Organisator != null)
                        tmt.Organisator = tournament.Organisator;

                    if (tournament.MatchIdList != null)
                    {
                        tmt.MatchList = dbContext.Matches.Where(x => tournament.MatchIdList.Contains(x.Id)).ToList();
                    }

                    if (tournament.TeamIdList != null)
                    {
                        tmt.TeamList = dbContext.Teams2Tournaments.Where(x => tournament.TeamIdList.Contains(x.TeamId)).ToList();
                    }


                    await dbContext.SaveChangesAsync();
                }
            }
        }


        public async static Task NewTournament(DtoTournament tournament)
        {
            using (var dbContext = new MyDbContext())
            {
                var matchlist = new List<Match>();
                if (tournament.MatchIdList != null)
                {
                    matchlist = dbContext.Matches.Where(x => tournament.MatchIdList.Contains(x.Id)).ToList();
                }

                var teamlist = new List<Team2Tournament>();
                if (tournament.TeamIdList != null)
                {
                    teamlist = dbContext.Teams2Tournaments.Where(x => tournament.TeamIdList.Contains(x.TeamId)).ToList();
                }

                var newTournament = new Tournament()
                {
                    City = tournament.City,
                    Date = tournament.Date ?? DateTime.Now,
                    Location = tournament.Location,
                    Name = tournament.Name,
                    Organisator = tournament.Organisator,
                    MatchList = matchlist,
                    TeamList = teamlist
                };

                dbContext.Tournaments.Add(newTournament);

                await dbContext.SaveChangesAsync();
            }
        }

    }
}
