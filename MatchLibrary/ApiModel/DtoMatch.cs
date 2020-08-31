using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// The Id of the first Team. 0 to use manual team and apply NameTeam1 value
        /// </summary>
        public int? Team1Id { get; set; }


        /// <summary>
        /// The Id of the second Team. 0 to use manual team and apply NameTeam2 value
        /// </summary>
        public int? Team2Id { get; set; }


        /// <summary>
        /// Name of Team1
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Name muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-äüößÄÜÖ\.]*$", ErrorMessage = "Der Name kann nur aus Buchstaben, Zahlen, Bindestrichen, Punkten und Leerzeichen bestehen")]
        public string NameTeam1 { get; set; }

        /// <summary>
        /// Name of Team2
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Name muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-äüößÄÜÖ\.]*$", ErrorMessage = "Der Name kann nur aus Buchstaben, Zahlen, Bindestrichen, Punkten und Leerzeichen bestehen")]
        public string NameTeam2 { get; set; }

        /// <summary>
        /// Time left
        /// </summary>
        [Range(0,int.MaxValue,ErrorMessage ="Die Zeit muss größer als 0 Sekunden sein.")]
        public int? TimeLeftSeconds { get; set; }

        /// <summary>
        /// Tournament this match belongs to
        /// </summary>
        //public DtoTournament Tournament { get; set; }
        public int? TournamentId { get; set; }

        /// <summary>
        /// Only for Livematches: The current status of the Match (see EnumMatchStatus for ID resolution)
        /// </summary>
        public int MatchStatus { get; set; }
    }
}
