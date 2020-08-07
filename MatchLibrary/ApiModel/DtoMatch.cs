using System;
using System.Collections.Generic;
using System.Text;

namespace MatchLibrary.ApiModel
{
    public class DtoMatch
    {
        /// <summary>
        /// The ID of the match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Scores of Team1
        /// </summary>
        public int? ScoreTeam1 { get; set; }

        /// <summary>
        /// Scores of Team2
        /// </summary>
        public int? ScoreTeam2 { get; set; }

        /// <summary>
        /// Name of Team1
        /// </summary>
        public string NameTeam1 { get; set; }
        
        /// <summary>
        /// Name of Team2
        /// </summary>
        public string NameTeam2 { get; set; }

        /// <summary>
        /// Time left
        /// </summary>
        public int? TimeLeftSeconds { get; set; }
    }
}
