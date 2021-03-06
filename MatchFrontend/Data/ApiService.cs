﻿using MatchLibrary;
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
//#if DEBUG
//        private static readonly string _ServerBaseUrl = "https://localhost:44302/api/";
//#else
        private static readonly string _ServerBaseUrl = "https://localhost:5001/api/";
//#endif
        
        public ApiService()
        {
            Console.WriteLine("Using Serverbase URL " + _ServerBaseUrl);
        }

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













        private HttpRequestMessage GetRequestMessage(string method, string uri, string json)
        {
            return new HttpRequestMessage()
            {
                Method = new HttpMethod(method),
                RequestUri = new Uri(_ServerBaseUrl + uri),
                Content = new StringContent(json)
            };
        }
    }
}
