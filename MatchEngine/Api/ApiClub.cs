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
    public static class ApiClub
    {
        /// <summary>
        /// Get a list of all Club
        /// </summary>
        public static string GetClubList()
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = new List<DtoClub>();
                foreach (var aClub in dbContext.Clubs)
                    dto.Add(aClub.ToDto());

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        /// <summary>
        /// Get a clubs
        /// </summary>
        public static string GetClub(int id)
        {
            using (var dbContext = new MyDbContext())
            {
                var dto = dbContext.Clubs.SingleOrDefault(x => x.Id == id);

                return JsonConvert.SerializeObject(dto, Helper.GetJsonSerializer());
            }
        }

        /// <summary>
        /// Get a clubs
        /// </summary>
        public static async Task SetClub(DtoClub club)
        {
            using (var dbContext = new MyDbContext())
            {
                var tm = dbContext.Clubs.SingleOrDefault(x => x.Id == club.Id);
                if (tm != null)
                {
                    if (club.OfficalName != null)
                        tm.OfficialName = club.OfficalName;

                    if (club.Contact != null)
                        tm.Contact = club.Contact;

                    if (club.Clubnumber != null)
                        tm.Clubnumber = club.Clubnumber;

                    if (club.Notes != null)
                        tm.Notes = club.Notes;

                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async static Task NewClub(DtoClub dtoClub)
        {
            using (var dbContext = new MyDbContext())
            {
                var club = new Club(dtoClub);
                
                dbContext.Clubs.Add(club);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
