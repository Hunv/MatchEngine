using MatchLibrary;
using MatchLibrary.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatchFrontend.Data
{
    public class ApiService
    {
        private static readonly string _ServerBaseUrl = "https://localhost:5001/api/";
        
        public ApiService()
        {
            Console.WriteLine("Using Serverbase URL " + _ServerBaseUrl);
        }

        #region Match

        /// <summary>
        /// Gets a Match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<DtoMatch> GetMatchAsync(int matchId)
        {
            var match = new DtoMatch();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "match/" + matchId))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                match = JsonConvert.DeserializeObject<DtoMatch>(json, Helper.GetJsonSerializer());
            }

            return match;
        }

        /// <summary>
        /// Gets the time left of a match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<int> GetMatchTimeAsync(int matchId)
        {
            var matchTime = new int();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "match/" + matchId + "/time"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                matchTime = JsonConvert.DeserializeObject<int>(json, Helper.GetJsonSerializer());
            }

            return matchTime;
        }

        /// <summary>
        /// Gets all Matches
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoMatch>> GetMatchListAsync()
        {
            var matchList = new List<DtoMatch>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "match"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                matchList = JsonConvert.DeserializeObject<List<DtoMatch>>(json, Helper.GetJsonSerializer());
            }

            return matchList;
        }

        /// <summary>
        /// Gets all running Matches
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoMatch>> GetLiveMatchListAsync()
        {
            var matchList = new List<DtoMatch>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "match/live"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                matchList = JsonConvert.DeserializeObject<List<DtoMatch>>(json, Helper.GetJsonSerializer());
            }

            return matchList;
        }

        /// <summary>
        /// Gets all Matches
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoMatch>> GetMatchListAsync(int tournamentId)
        {
            var matchList = new List<DtoMatch>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "tournament/" + tournamentId + "/matchlist"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                matchList = JsonConvert.DeserializeObject<List<DtoMatch>>(json, Helper.GetJsonSerializer());
            }

            return matchList;
        }


        /// <summary>
        /// Add a new Tournament
        /// </summary>
        /// <param name="match"></param>
        public async Task AddMatchAsync(DtoMatch match)
        {
            var json = JsonConvert.SerializeObject(match, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("POST", "match", json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Add a new Tournament
        /// </summary>
        /// <param name="match"></param>
        public async Task SetMatchAsync(DtoMatch match)
        {
            var json = JsonConvert.SerializeObject(match, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "match/" + match.Id, json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Send Control Commands of a Match
        /// </summary>
        public async Task ControlMatchtimeAsync(int matchId, string command)
        {
            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "match/" + matchId + "/time/" + command, "");
            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task SetMatchGoalAsync(int matchId, int teamId, int amount)
        {
            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "match/" + matchId + "/goal/" + teamId + "/" + amount, "");
            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        #endregion


        #region Tournament
        /// <summary>
        /// Add a new Tournament
        /// </summary>
        /// <param name="tournament"></param>
        public async Task AddTournamentAsync(DtoTournament tournament)
        {
            var json = JsonConvert.SerializeObject(tournament, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("POST", "tournament", json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }
        
        /// <summary>
        /// Gets all Tournaments
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTournament>> GetTournamentListAsync()
        {
            var tournamentList = new List<DtoTournament>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "tournament"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                tournamentList = JsonConvert.DeserializeObject<List<DtoTournament>>(json, Helper.GetJsonSerializer());
            }

            return tournamentList;
        }

        /// <summary>
        /// Gets a Tournament
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        public async Task<DtoTournament> GetTournamentAsync(int tournamentId)
        {
            var tournament = new DtoTournament();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "tournament/" + tournamentId))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                tournament = JsonConvert.DeserializeObject<DtoTournament>(json, Helper.GetJsonSerializer());
            }

            return tournament;
        }

        /// <summary>
        /// Add a new Tournament
        /// </summary>
        /// <param name="tournament"></param>
        public async Task SetTournamentAsync(DtoTournament tournament)
        {
            var json = JsonConvert.SerializeObject(tournament, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "tournament/" + tournament.Id, json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }
        #endregion


        /// <summary>
        /// Get all Teams
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoTeam>> GetTeamListAsync()
        {
            var teamList = new List<DtoTeam>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "team"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                teamList = JsonConvert.DeserializeObject<List<DtoTeam>>(json, Helper.GetJsonSerializer());
            }

            return teamList;
        }

        /// <summary>
        /// Gets a Team
        /// </summary>
        /// <returns></returns>
        public async Task<DtoTeam> GetTeamAsync(int id)
        {
            var team = new DtoTeam();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "team/" + id))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                team = JsonConvert.DeserializeObject<DtoTeam>(json, Helper.GetJsonSerializer());
            }

            return team;
        }

        /// <summary>
        /// Add a new Team
        /// </summary>
        /// <param name="team"></param>
        public async Task AddTeamAsync(DtoTeam team)
        {
            var json = JsonConvert.SerializeObject(team, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("POST", "team", json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }


        /// <summary>
        /// Edit a Team
        /// </summary>
        /// <param name="team"></param>
        public async Task SetTeamAsync(DtoTeam team)
        {
            var json = JsonConvert.SerializeObject(team, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "team/" + team.Id, json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }


        /// <summary>
        /// Add a new Club
        /// </summary>
        /// <param name="club"></param>
        public async Task AddClubAsync(DtoClub club)
        {
            var json = JsonConvert.SerializeObject(club, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("POST", "club", json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Get all Clubs
        /// </summary>
        /// <returns></returns>
        public async Task<List<DtoClub>> GetClubListAsync()
        {
            var clubList = new List<DtoClub>();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "club"))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                clubList = JsonConvert.DeserializeObject<List<DtoClub>>(json, Helper.GetJsonSerializer());
            }

            return clubList;
        }


        /// <summary>
        /// Gets a Club
        /// </summary>
        /// <returns></returns>
        public async Task<DtoClub> GetClubAsync(int id)
        {
            var club = new DtoClub();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "club/" + id))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                club = JsonConvert.DeserializeObject<DtoClub>(json, Helper.GetJsonSerializer());
            }

            return club;
        }

        /// <summary>
        /// Edit a Club
        /// </summary>
        /// <param name="club"></param>
        public async Task SetClubAsync(DtoClub club)
        {
            var json = JsonConvert.SerializeObject(club, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "club/" + club.Id, json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Gets a Setting
        /// </summary>
        /// <returns></returns>
        public async Task<DtoSetting> GetSettingAsync(string name)
        {
            var setting = new DtoSetting();
            HttpClient client = new HttpClient();

            using (var jsonStream = await client.GetStreamAsync(_ServerBaseUrl + "setting/" + name))
            {
                var sR = new StreamReader(jsonStream);
                var json = await sR.ReadToEndAsync();
                sR.Close();

                setting = JsonConvert.DeserializeObject<DtoSetting>(json, Helper.GetJsonSerializer());
            }

            return setting;
        }

        /// <summary>
        /// Edit a Setting
        /// </summary>
        /// <param name="club"></param>
        public async Task SetSettingAsync(DtoSetting setting)
        {
            var json = JsonConvert.SerializeObject(setting, Helper.GetJsonSerializer());

            HttpClient client = new HttpClient();
            var requestMessage = GetRequestMessage("PUT", "setting", json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
            }
        }




        #region Helper

        private HttpRequestMessage GetRequestMessage(string method, string uri, string json)
        {
            return new HttpRequestMessage()
            {
                Method = new HttpMethod(method),
                RequestUri = new Uri(_ServerBaseUrl + uri),
                Content = new StringContent(json)
            };
        }
        #endregion
    }
}
