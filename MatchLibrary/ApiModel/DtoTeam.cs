using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.ApiModel
{
    public class DtoTeam
    {
        /// <summary>
        /// The ID of the team
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Team
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Name muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-äüößÄÜÖ\.]*$", ErrorMessage = "Der Name kann nur aus Buchstaben, Zahlen, Bindestrichen, Punkten und Leerzeichen bestehen")]
        public string Name { get; set; }

        /// <summary>
        /// A short version of the Teamname
        /// </summary>
        [MaxLength(32, ErrorMessage = "Der Kurzname kann höchstens aus 32 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Kurzname muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-äüößÄÜÖ\.]*$", ErrorMessage = "Der Kurzname kann nur aus Buchstaben, Zahlen, Bindestrichen, Punkten und Leerzeichen bestehen")]
        public string Shortname { get; set; }

        /// <summary>
        /// A shortcut for the teamname
        /// </summary>
        [MaxLength(5, ErrorMessage = "Die Abkürzung kann höchstens aus fünf Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Die Abkürzung  muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-äüößÄÜÖ\.]*$", ErrorMessage = "Die Abkürzung kann nur aus Buchstaben, Zahlen, Bindestrichen, Punkten und Leerzeichen bestehen")]
        public string Shortcut { get; set; }

        /// <summary>
        /// The name of the teamcaptain
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name des Teamcaptains kann höchstens aus 256 Zeichen bestehen.")]
        [MinLength(2, ErrorMessage = "Der Name des Teamcaptains muss mindestens aus zwei Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z\säüößÄÜÖ]*$", ErrorMessage = "Der Name des Teamcaptains kann nur aus Buchstaben, Bindestrichen und Leerzeichen bestehen")]
        public string Teamcaptain { get; set; }

        /// <summary>
        /// The name of the vice teamcaptain
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name des Vize Teamcaptains kann höchstens aus 256 Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z\säüößÄÜÖ]*$", ErrorMessage = "Der Name des Vize Teamcaptains kann nur aus Buchstaben, Bindestrichen und Leerzeichen bestehen")]
        public string ViceTeamcaptain { get; set; }

        /// <summary>
        /// The name of the coach
        /// </summary>
        [MaxLength(256, ErrorMessage = "Der Name des Coaches kann höchstens aus 256 Zeichen bestehen.")]
        [RegularExpression(@"^[a-zA-Z\säüößÄÜÖ]*$", ErrorMessage = "Der Name des Coaches kann nur aus Buchstaben, Bindestrichen und Leerzeichen bestehen")]
        public string Coach { get; set; }

        /// <summary>
        /// ID of the Club
        /// </summary>
        public int ClubId { get; set; }

        /// <summary>
        /// Notes regarding this team
        /// </summary>        
        public string Notes { get; set; }

        /// <summary>
        /// List of tournaments where this team is participating
        /// </summary>
        public List<int> TournamentIdList { get; set; }

        /// <summary>
        /// List of matches where this team is participating
        /// </summary>
        public List<int> MatchIdList { get; set; }
    }
}
