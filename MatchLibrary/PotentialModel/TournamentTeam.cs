using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MatchLibrary.PotentialModel
{
    public class TournamentTeam
    {
        /// <summary>
        /// The internal ID of the Tournament Team
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The offical Name of the Team
        /// Examples: "ETSV Schlickteufel", "Spielgemeinschaft Hannover, Berlin, Heidelberg"
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Name of the team like it will be displayed on Dashboards etc.
        /// Examples: "Schlickteufel", "Spielgemeinschaft"
        /// </summary>
        [Required]
        public string Displayname { get; set; }

        /// <summary>
        /// A Short version of the teamname
        /// Examples: "ETSV", "Spgm"
        /// </summary>
        [Required]
        [MaxLength(5)]
        public string Shortname { get; set; }

        /// <summary>
        /// The players of this team
        /// </summary>
        [Required]
        public List<TournamentPlayer> PlayerList { get; set; }

        /// <summary>
        /// The team captain
        /// </summary>
        [Required]
        public Player Captain { get; set; }

        /// <summary>
        /// The co team captain
        /// </summary>
        [Required]
        public Player CoCaptain { get; set; }

        /// <summary>
        /// The coach, trainer, ...
        /// </summary>
        [Required]
        public Player Coach { get; set; }

        /// <summary>
        /// The Tournament the Team is participating on
        /// </summary>
        [Required]
        public Tournament Tournament { get; set; }
    }
}